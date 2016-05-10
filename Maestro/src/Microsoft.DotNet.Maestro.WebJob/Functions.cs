// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.DotNet.Maestro.Handlers;
using Microsoft.DotNet.Maestro.Messages;
using Newtonsoft.Json;

namespace Microsoft.DotNet.Maestro.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on the DelayedMessage.QueueName Azure Queue.
        public static async Task ProcessQueueMessage(
            [QueueTrigger(DelayedMessage.QueueName)] DelayedMessage message,
            TextWriter log)
        {
            await log.WriteLineAsync("Starting " + message);

            await log.WriteLineAsync($"Deserializing {message.HandlerType}");
            Type handlerType = Type.GetType(message.HandlerType);
            if (handlerType == null)
            {
                await log.WriteLineAsync($"Could not find type '{message.HandlerType}'. Skipping message '{message.HandlerData}'.");
                return;
            }

            ISubscriptionHandler handler = (ISubscriptionHandler)JsonConvert.DeserializeObject(message.HandlerData, handlerType);
            await handler.Execute();
        }
    }
}
