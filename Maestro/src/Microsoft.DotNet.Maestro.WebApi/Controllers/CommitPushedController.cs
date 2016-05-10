// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.DotNet.Maestro.Handlers;
using Microsoft.DotNet.Maestro.Messages;
using Microsoft.DotNet.Maestro.WebApi.Models;
using Microsoft.DotNet.Maestro.WebApi.Services;
using Newtonsoft.Json;

namespace Microsoft.DotNet.Maestro.WebApi.Controllers
{
    public class CommitPushedController : ApiController
    {
        private EventRegistrationTable _eventService = new EventRegistrationTable();
        private AzureStorageService _storageService = new AzureStorageService();

        public async Task Post(PushWebHookEvent e)
        {
            Trace.TraceInformation($"CommitPushed Started: {e}");

            try
            {
                if (e.Commits != null)
                {
                    foreach (Commit c in e.Commits)
                    {
                        if (c.modified != null)
                        {
                            foreach (string modified in c.modified)
                            {
                                ModifiedFileModel modifiedFile;
                                if (!ModifiedFileModel.TryParse(e.Repository.Full_Name, e.Ref, modified, out modifiedFile))
                                {
                                    Trace.TraceWarning($"Skipping file '{modified}'");
                                    continue;
                                }

                                List<Task> handlerTasks = new List<Task>();
                                foreach (ISubscriptionHandler handler in await _eventService.GetSubscriptionHandlers(modifiedFile))
                                {
                                    if (handler.Delay.HasValue)
                                    {
                                        DelayedMessage message = new DelayedMessage();
                                        message.HandlerType = handler.GetType().AssemblyQualifiedName;
                                        message.HandlerData = JsonConvert.SerializeObject(handler);

                                        handlerTasks.Add(
                                            _storageService.EnqueueMessage(
                                                DelayedMessage.QueueName, 
                                                JsonConvert.SerializeObject(message), 
                                                handler.Delay));
                                    }
                                    else
                                    {
                                        handlerTasks.Add(handler.Execute());
                                    }
                                }

                                await Task.WhenAll(handlerTasks);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError($"An unhandled exception occurred handling PushWebHookEvent {e} : Exception: {ex}");

                throw;
            }

            Trace.TraceInformation("CommitPushed Complete");
        }
    }
}
