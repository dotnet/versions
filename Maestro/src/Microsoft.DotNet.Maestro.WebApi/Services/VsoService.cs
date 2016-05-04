using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    public class VsoService
    {
        private static HttpClient client = new HttpClient();
        private const string apiVersion = "2.0";

        static VsoService()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
               Convert.ToBase64String(
                   Encoding.ASCII.GetBytes(
                       string.Format("{0}:{1}", Config.Instance.VSoUser, Config.Instance.VSoPassword))));
        }

        public async Task QueueBuildAsync(string instance, string project, int buildDefinitionId, string parameters)
        {
            string queueBuildUrl = $"https://{instance}/defaultcollection/{project}/_apis/build/builds?api-version={apiVersion}";

            Build build = new Build()
            {
                Definition = new BuildDefinitionRef() { Id = buildDefinitionId },
                Parameters = parameters
            };

            JsonMediaTypeFormatter formatter = new JsonMediaTypeFormatter();
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            ObjectContent queueBuildContent = new ObjectContent<Build>(build, formatter);

            HttpResponseMessage response = await client.PostAsync(queueBuildUrl, queueBuildContent);
            if (!response.IsSuccessStatusCode)
            {
                Trace.TraceError($"Error queuing VSO build to '{queueBuildUrl}'\nBody: {await queueBuildContent.ReadAsStringAsync()}\n\nResponse StatusCode: {response.StatusCode}\nResponse Body: {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                Trace.TraceInformation($"Successfully queued VSO build.{Environment.NewLine}Response Body: {await response.Content.ReadAsStringAsync()}");
            }
        }

        private class Build
        {
            public BuildDefinitionRef Definition { get; set; }

            public string Parameters { get; set; }
        }

        private class BuildDefinitionRef
        {
            public int Id { get; set; }
        }
    }
}