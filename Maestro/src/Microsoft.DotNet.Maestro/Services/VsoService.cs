// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Microsoft.DotNet.Maestro.Services
{
    public class VsoService
    {
        private static HttpClient client = new HttpClient();
        private const string apiVersion = "2.0";

        public async Task QueueBuildAsync(string instance, string project, int buildDefinitionId, string sourceBranch, string parameters)
        {
            string queueBuildUrl = $"https://{instance}/defaultcollection/{project}/_apis/build/builds?api-version={apiVersion}";

            Build build = new Build()
            {
                Definition = new BuildDefinitionRef() { Id = buildDefinitionId },
                SourceBranch = sourceBranch,
                Parameters = parameters
            };

            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            ObjectContent queueBuildContent = new ObjectContent<Build>(build, formatter);
            string queueBuildContentString = await queueBuildContent.ReadAsStringAsync();

            HttpRequestMessage postMessage = new HttpRequestMessage(HttpMethod.Post, queueBuildUrl);
            postMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic",
               Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Config.Instance.VstsUsername}:{Config.Instance.GetPassword(instance)}")));
            postMessage.Content = queueBuildContent;
            HttpResponseMessage response = await client.SendAsync(postMessage);
            if (!response.IsSuccessStatusCode)
            {
                Trace.TraceError($"Error queuing VSO build to '{queueBuildUrl}'\nBody: {queueBuildContentString}\n\nResponse StatusCode: {response.StatusCode}\nResponse Body: {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                Trace.TraceInformation($"Successfully queued VSO build.{Environment.NewLine}Response Body: {await response.Content.ReadAsStringAsync()}");
            }
        }

        private class Build
        {
            public BuildDefinitionRef Definition { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string SourceBranch { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string Parameters { get; set; }
        }

        private class BuildDefinitionRef
        {
            public int Id { get; set; }
        }
    }
}