// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.DotNet.Maestro.Models;

namespace Microsoft.DotNet.Maestro.WebApi.Models
{
    public class Subscription
    {
        public string Path { get; set; }
        public List<HandlerObject> Handlers { get; set; }
    }
}