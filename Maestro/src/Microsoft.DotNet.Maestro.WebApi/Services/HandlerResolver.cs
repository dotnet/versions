// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.DotNet.Maestro.Handlers;
using Microsoft.DotNet.Maestro.Models;
using Microsoft.DotNet.Maestro.WebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    public class HandlerResolver
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
                throw new Exception("All Subscription Handler objects must contain a 'maestroAction' property.");
            }

            JObject action = _subscriptionsModel.Actions.GetAction(handlerObject.MaestroAction);
            if (action == null)
            {
                throw new Exception($"Could not find a valid action with name '{handlerObject.MaestroAction}'.");
            }

            ISubscriptionHandler result = VsoBuildHandler.TryCreate(action, handlerObject);

            if (result == null)
            {
                throw new Exception($"Could not resolve a Handler for Subscription '{JsonConvert.SerializeObject(handlerObject)}'.");
            }
            return result;
        }
    }
}