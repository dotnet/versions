// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.DotNet.Maestro.Models;
using Microsoft.DotNet.Maestro.Services;
using Newtonsoft.Json.Linq;

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

        public static ISubscriptionHandler TryCreate(JObject action, HandlerObject handlerObject)
        {
            if (action.Property("vsoInstance") != null)
            {
                // It's a VSO build definition
                return new VsoBuildHandler()
                {
                    Delay = handlerObject.MaestroDelay,
                    VsoInstance = action["vsoInstance"].ToString(),
                    VsoProject = action["vsoProject"].ToString(),
                    BuildDefinitionId = action["buildDefinitionId"].Value<int>(),
                    SourceBranch = GetSourceBranch(handlerObject),
                    VsoParameters = VsoParameterGenerator.GetParameters(handlerObject.ExtensionData, FilterParameters)
                };
            }

            return null;
        }

        private static string GetSourceBranch(HandlerObject handlerObject)
        {
            JToken sourceBranchToken = null;
            handlerObject.ExtensionData.TryGetValue("vsoSourceBranch", out sourceBranchToken);

            return sourceBranchToken?.ToString();
        }

        private static bool FilterParameters(string parameterKey)
        {
            return parameterKey != "vsoSourceBranch";
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
    }
}