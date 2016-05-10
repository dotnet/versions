// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    public class AzureStorageService
    {
        private CloudQueueClient _queueClient;

        public AzureStorageService()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Config.Instance.AzureWebJobsStorage);
            _queueClient = storageAccount.CreateCloudQueueClient();
        }

        public async Task EnqueueMessage(string queueName, string message, TimeSpan? delay)
        {
            CloudQueue queue = _queueClient.GetQueueReference(queueName);
            await queue.CreateIfNotExistsAsync();

            await queue.AddMessageAsync(new CloudQueueMessage(message), null, delay, null, null);
        }
    }
}