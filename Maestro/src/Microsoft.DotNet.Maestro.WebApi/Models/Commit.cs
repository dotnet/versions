// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.DotNet.Maestro.WebApi.Models
{
    public class Commit
    {
        public string id { get; set; }

        public string[] added { get; set; }
        public string[] modified { get; set; }
        public string[] removed { get; set; }

        public IEnumerable<string> GetAllChangedFiles()
        {
            return (added ?? Enumerable.Empty<string>())
                .Union(modified ?? Enumerable.Empty<string>())
                .Union(removed ?? Enumerable.Empty<string>());
        }
    }
}