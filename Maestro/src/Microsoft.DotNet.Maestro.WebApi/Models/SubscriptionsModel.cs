// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.DotNet.Maestro.Handlers;
using Microsoft.DotNet.Maestro.Models;
using Microsoft.DotNet.Maestro.WebApi.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.DotNet.Maestro.WebApi.Models
{
    public class SubscriptionsModel
    {
        private static HttpClient s_client = new HttpClient();
        private static JsonSerializerSettings s_settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            MissingMemberHandling = MissingMemberHandling.Error
        };

        [JsonProperty(Required = Required.Always)]
        public ActionsList Actions { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<Subscription> Subscriptions { get; set; }

        public static async Task<SubscriptionsModel> CreateAsync()
        {
            string subscriptionsString = await s_client.GetStringAsync(Config.Instance.SubscriptionsUrl);

            return Create(subscriptionsString);
        }

        public static SubscriptionsModel Create(string subscriptionsString)
        {
            return JsonConvert.DeserializeObject<SubscriptionsModel>(subscriptionsString, s_settings);
        }

        public IEnumerable<ISubscriptionHandler> GetHandlers(ModifiedFileModel modifiedFile)
        {
            List<ISubscriptionHandler> subscriptionHandlers = new List<ISubscriptionHandler>();
            HandlerResolver resolver = new HandlerResolver(this);

            foreach (Subscription subscription in GetSubscriptions(modifiedFile))
            {
                try
                {
                    var parameterSubstitutions = new Dictionary<string, string>
                    {
                        { "<trigger-repo>", modifiedFile.RepoName},
                        { "<trigger-branch>", modifiedFile.BranchName },
                        { "<trigger-path>", modifiedFile.FullPath },
                        { "<trigger-commit>", modifiedFile.CommitId },
                        { "<trigger-commitlist>", modifiedFile.CommitList },
                    };

                    ISubscriptionHandler subscriptionHandler = resolver.Resolve(subscription, parameterSubstitutions);
                    subscriptionHandlers.Add(subscriptionHandler);
                }
                catch (Exception e)
                {
                    Trace.TraceError(e.Message);
                }
            }

            return subscriptionHandlers;
        }

        private IEnumerable<Subscription> GetSubscriptions(ModifiedFileModel modifiedFile)
        {
            return Subscriptions.Where(s => s.TriggerPaths.Any(p => Matches(p, modifiedFile)));
        }

        private bool Matches(string path, ModifiedFileModel modifiedFile)
        {
            bool matches = string.Equals(path, modifiedFile.FullPath, StringComparison.OrdinalIgnoreCase);
            if (matches)
            {
                return true;
            }

            if (path.EndsWith("/**/*", StringComparison.OrdinalIgnoreCase))
            {
                string rootPath = path.Substring(0, path.Length - 5);
                return modifiedFile.FullPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}