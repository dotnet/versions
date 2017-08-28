// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Microsoft.DotNet.Maestro.Handlers;
using Microsoft.DotNet.Maestro.Models;
using Microsoft.DotNet.Maestro.WebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    public class HandlerResolver
    {
        private SubscriptionsModel _subscriptionsModel;

        public HandlerResolver(SubscriptionsModel subscriptionsModel)
        {
            _subscriptionsModel = subscriptionsModel;
        }

        public ISubscriptionHandler Resolve(Subscription subscription, IDictionary<string, string> parameterSubstitutions = null)
        {
            JObject action = _subscriptionsModel.Actions.GetAction(subscription.Action);
            if (action == null)
            {
                throw new Exception($"Could not find a valid action with name '{subscription.Action}'.");
            }

            ISubscriptionHandler result = VsoBuildHandler.TryCreate(action, subscription, parameterSubstitutions);

            if (result == null)
            {
                throw new Exception($"Could not resolve a Handler for Subscription '{JsonConvert.SerializeObject(subscription)}'.");
            }
            return result;
        }
    }
}