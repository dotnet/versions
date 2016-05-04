// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.DotNet.Maestro.WebApi.Handlers;
using Microsoft.DotNet.Maestro.WebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    public class EventRegistrationTable
    {
        private static HttpClient s_client = new HttpClient();
        private static JsonSerializerSettings s_settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };


        private SubscriptionsModel SubscriptionModel { get; set; }

        public async Task<IEnumerable<ISubscriptionHandler>> GetSubscriptionHandlers(ModifiedFileModel modifiedFile)
        {
            if (SubscriptionModel == null)
            {
                await InitializeSubscriptionModel();
            }

            return SubscriptionModel.GetHandlers(modifiedFile);
        }

        private async Task InitializeSubscriptionModel()
        {
            string subscriptionsString = await s_client.GetStringAsync(Config.Instance.SubscriptionsUrl);

            SubscriptionModel = JsonConvert.DeserializeObject<SubscriptionsModel>(subscriptionsString, s_settings);
        }

        private class SubscriptionsModel
        {
            public ActionsList Actions { get; set; }
            public List<Subscription> Subscriptions { get; set; }

            public IEnumerable<ISubscriptionHandler> GetHandlers(ModifiedFileModel modifiedFile)
            {
                List<ISubscriptionHandler> subscriptionHandlers = new List<ISubscriptionHandler>();
                HandlerResolver resolver = new HandlerResolver(this);

                foreach (HandlerObject handlerObject in GetHandlerObjects(modifiedFile))
                {
                    ISubscriptionHandler subscriptionHandler = resolver.Resolve(handlerObject);
                    if (subscriptionHandler != null)
                    {
                        subscriptionHandlers.Add(subscriptionHandler);
                    }
                }

                return subscriptionHandlers;
            }

            private IEnumerable<HandlerObject> GetHandlerObjects(ModifiedFileModel modifiedFile)
            {
                return Subscriptions
                    .Where(s => string.Equals(s.Path, modifiedFile.FullPath, StringComparison.OrdinalIgnoreCase))
                    .SelectMany(s => s.Handlers);
            }
        }

        private class Subscription
        {
            public string Path { get; set; }
            public List<HandlerObject> Handlers { get; set; }
        }

        private class HandlerObject
        {
            public string MaestroAction { get; set; }

            [JsonExtensionData]
            public IDictionary<string, JToken> Parameters { get; set; }
        }

        private class ActionsList
        {
            [JsonExtensionData]
            private IDictionary<string, JToken> ActionNames { get; set; }

            public JObject GetAction(string name)
            {
                JObject action = null;

                if (!string.IsNullOrEmpty(name))
                {
                    JToken token;
                    if (ActionNames.TryGetValue(name, out token))
                    {
                        action = token as JObject;
                    }
                }

                return action;
            }
        }

        private class HandlerResolver
        {
            private SubscriptionsModel _subscriptionsModel;

            public HandlerResolver(SubscriptionsModel subscriptionsModel)
            {
                _subscriptionsModel = subscriptionsModel;
            }

            public ISubscriptionHandler Resolve(HandlerObject handlerObject)
            {
                if (string.IsNullOrEmpty(handlerObject.MaestroAction))
                {
                    Trace.TraceError("All Subscription Handler objects must contain a 'maestroAction' property.");
                    return null;
                }

                JObject action = _subscriptionsModel.Actions.GetAction(handlerObject.MaestroAction);
                if (action == null)
                {
                    Trace.TraceError($"Could not find a valid action with name '{handlerObject.MaestroAction}'.");
                    return null;
                }

                if (action.Property("vsoInstance") != null)
                {
                    // It's a VSO build definition
                    return new VsoBuildHandler()
                    {
                        VsoInstance = action["vsoInstance"].ToString(),
                        VsoProject = action["vsoProject"].ToString(),
                        BuildDefinitionId = action["buildDefinitionId"].Value<int>(),
                        VsoParameters = VsoParameterGenerator.GetParameters(handlerObject.Parameters)
                    };
                }

                Trace.TraceError($"Could not resolve a Handler for Subscription '{JsonConvert.ToString(handlerObject)}'.");
                return null;
            }
        }
    }
}
