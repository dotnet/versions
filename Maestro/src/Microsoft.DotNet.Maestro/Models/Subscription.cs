// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.Maestro.Models
{
    public class Subscription
    {
        [JsonProperty(Required = Required.Always)]
        public List<string> TriggerPaths { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Action { get; set; }

        public TimeSpan? Delay { get; set; }
        public IDictionary<string, JToken> ActionArguments { get; set; }
    }
}