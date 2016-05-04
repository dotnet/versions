// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.DotNet.Maestro.WebApi.Models;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    public class EventRegistrationTable
    {
        private static HttpClient s_client = new HttpClient();

        private SubscriptionsModel SubscriptionModel { get; set; }

        public async Task<IEnumerable<EventRegistration>> GetRegistrations(ModifiedFileModel modifiedFile)
        {
            if (SubscriptionModel == null)
            {
                await InitializeSubscriptionModel();
            }

            return SubscriptionModel.GetRegistrations(modifiedFile);
        }

        private async Task InitializeSubscriptionModel()
        {
            string subscriptionsString = await s_client.GetStringAsync(Config.Instance.SubscriptionsUrl);

            SubscriptionModel = JsonConvert.DeserializeObject<SubscriptionsModel>(subscriptionsString);
        }

        private class SubscriptionsModel
        {
            public BuildDefinitionList NamedVsoBuildDefinitions { get; set; }
            public SubscriptionList Subscriptions { get; set; }

            public IEnumerable<EventRegistration> GetRegistrations(ModifiedFileModel modifiedFile)
            {
                List<EventRegistration> registrations = new List<EventRegistration>();

                foreach (Subscription subscription in Subscriptions.GetSubscriptions(modifiedFile))
                {
                    BuildDefinition buildDefinition = GetBuildDefinition(subscription);
                    string parameters = VsoParameterGenerator.GetParameters(subscription.VsoParameters);

                    registrations.Add(new EventRegistration()
                    {
                        VsoInstance = buildDefinition.VsoInstance,
                        VsoProject = buildDefinition.VsoProject,
                        BuildDefinitionId = buildDefinition.BuildDefinitionId,
                        VsoParameters = parameters
                    });
                }

                return registrations;
            }

            private BuildDefinition GetBuildDefinition(Subscription subscription)
            {
                // first look to see if there is a NamedVsoBuildDefinition property and a
                // valid VsoBuildDefinition with that name
                BuildDefinition buildDefinition = NamedVsoBuildDefinitions.GetBuildDefinition(subscription);

                // if that doesn't exist, get the BuildDefinition from the properties directly
                if (buildDefinition == null)
                {
                    buildDefinition = new BuildDefinition()
                    {
                        VsoInstance = subscription.VsoInstance,
                        VsoProject = subscription.VsoProject,
                        BuildDefinitionId = subscription.BuildDefinitionId,
                    };
                }

                return buildDefinition;
            }
        }

        private class SubscriptionList
        {
            [JsonExtensionData]
            private IDictionary<string, JToken> SubscribedFiles { get; set; }

            public IEnumerable<Subscription> GetSubscriptions(ModifiedFileModel modifiedFile)
            {
                foreach (string fileName in SubscribedFiles.Keys)
                {
                    if (string.Equals(fileName, modifiedFile.FullPath, StringComparison.OrdinalIgnoreCase))
                    {
                        return JsonConvert.DeserializeObject<Subscription[]>(SubscribedFiles[fileName].ToString());
                    }
                }

                return Enumerable.Empty<Subscription>();
            }
        }

        private class Subscription
        {
            public string NamedVsoBuildDefinition { get; set; }

            public string VsoProject { get; set; }
            public string VsoInstance { get; set; }
            public int BuildDefinitionId { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> VsoParameters { get; set; }
        }

        private class BuildDefinitionList
        {
            [JsonExtensionData]
            private IDictionary<string, JToken> BuildNames { get; set; }

            public BuildDefinition GetBuildDefinition(Subscription subscription)
            {
                BuildDefinition buildDefinition = null;

                if (!string.IsNullOrEmpty(subscription.NamedVsoBuildDefinition))
                {
                    JToken token;
                    if (BuildNames.TryGetValue(subscription.NamedVsoBuildDefinition, out token))
                    {
                        buildDefinition = JsonConvert.DeserializeObject<BuildDefinition>(token.ToString());
                    }
                }

                return buildDefinition;
            }
        }

        private class BuildDefinition
        {
            public string VsoProject { get; set; }
            public string VsoInstance { get; set; }
            public int BuildDefinitionId { get; set; }
        }
    }
}