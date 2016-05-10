// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;

namespace Microsoft.DotNet.Maestro.Handlers
{
    public interface ISubscriptionHandler
    {
        TimeSpan? Delay { get; }

        Task Execute();
    }
}
