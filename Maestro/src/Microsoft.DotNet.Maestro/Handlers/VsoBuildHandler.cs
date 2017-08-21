// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.DotNet.Maestro.Models;
using Microsoft.DotNet.Maestro.Services;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Microsoft.DotNet.Maestro.Handlers
{
    public class VsoBuildHandler : ISubscriptionHandler
    {
        [IgnoreDataMember]
        public VsoService VsoService { get; } = new VsoService();

        [IgnoreDataMember]
        public TimeSpan? Delay { get; set; }

        public string VsoInstance { get; set; }
        public string VsoProject { get; set; }
        public int BuildDefinitionId { get; set; }
        public string SourceBranch { get; set; }
        public string VsoParameters { get; set; }

        public static ISubscriptionHandler TryCreate(JObject action, Subscription subscription, IDictionary<string, string> parameterSubstitutions)
        {
            if (action.Property("vsoInstance") != null)
            {
                // It's a VSO build definition
                return new VsoBuildHandler()
                {
                    Delay = subscription.Delay,
                    VsoInstance = action["vsoInstance"].ToString(),
                    VsoProject = action["vsoProject"].ToString(),
                    BuildDefinitionId = action["buildDefinitionId"].Value<int>(),
                    SourceBranch = GetSourceBranch(subscription),
                    VsoParameters = VsoParameterGenerator.GetParameters(subscription.ActionArguments, parameterSubstitutions)
                };
            }

            return null;
        }

        private static string GetSourceBranch(Subscription subscription)
        {
            JToken sourceBranchToken = null;
            subscription.ActionArguments?.TryGetValue("vsoSourceBranch", out sourceBranchToken);

            return sourceBranchToken?.ToString();
        }

        public Task Execute()
        {
            return VsoService.QueueBuildAsync(
                VsoInstance,
                VsoProject,
                BuildDefinitionId,
                SourceBranch,
                VsoParameters);
        }

        public override bool Equals(object obj)
        {
            VsoBuildHandler other = obj as VsoBuildHandler;
            if (other == null)
            {
                return false;
            }

            return Delay == other.Delay &&
                VsoInstance == other.VsoInstance &&
                VsoProject == other.VsoProject &&
                BuildDefinitionId == other.BuildDefinitionId &&
                SourceBranch == other.SourceBranch &&
                VsoParameters == other.VsoParameters;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Delay?.GetHashCode() ?? 0 +
                    VsoInstance.GetHashCode() +
                    VsoProject.GetHashCode() +
                    BuildDefinitionId.GetHashCode() +
                    SourceBranch?.GetHashCode() ?? 0 +
                    VsoParameters?.GetHashCode() ?? 0;
            }
        }
    }
}