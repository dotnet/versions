// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Linq;
using Microsoft.DotNet.Maestro.Models;
using Microsoft.DotNet.Maestro.WebApi.Models;
using Microsoft.DotNet.Maestro.WebApi.Services;
using Xunit;

namespace Microsoft.DotNet.Maestro.SubscriptionValidation
{
    public class SubscriptionValidationTests
    {
        [Fact]
        public void SubscriptionsJsonShouldHaveValidHandlers()
        {
            SubscriptionsModel subscriptionsModel = InitializeSubscriptionsModel();
            HandlerResolver resolver = new HandlerResolver(subscriptionsModel);

            foreach (HandlerObject handlerObject in subscriptionsModel.Subscriptions.SelectMany(s => s.Handlers))
            {
                resolver.Resolve(handlerObject);
            }
        }

        [Fact]
        public void SubscriptionsJsonShouldHaveValidPaths()
        {
            SubscriptionsModel subscriptionsModel = InitializeSubscriptionsModel();

            foreach (string path in subscriptionsModel.Subscriptions.Select(s => s.Path))
            {
                Assert.True(Uri.IsWellFormedUriString(path, UriKind.Absolute), $"The path '{path}' is not valid.");
            }
        }

        private SubscriptionsModel InitializeSubscriptionsModel()
        {
            string subscriptionsJsonContent = File.ReadAllText("subscriptions.json");
            return SubscriptionsModel.Create(subscriptionsJsonContent);
        }
    }
}
