// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using Microsoft.DotNet.Maestro.WebApi.Services;

namespace Microsoft.DotNet.Maestro.WebApi.Handlers
{
    public class VsoBuildHandler : ISubscriptionHandler
    {
        public VsoService VsoService { get; } = new VsoService();

        public string VsoInstance { get; set; }
        public string VsoProject { get; set; }
        public int BuildDefinitionId { get; set; }
        public string VsoParameters { get; set; }

        public Task Execute()
        {
            return VsoService.QueueBuildAsync(
                VsoInstance,
                VsoProject,
                BuildDefinitionId,
                VsoParameters);
        }
    }
}