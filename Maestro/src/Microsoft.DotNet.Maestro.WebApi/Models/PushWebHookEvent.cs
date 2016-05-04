using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Microsoft.DotNet.Maestro.WebApi.Models
{
    public class PushWebHookEvent
    {
        [DataMember(Name = "ref")]
        public string Ref { get; set; }

        [DataMember(Name = "commits")]
        public List<Commit> Commits { get; set; }

        [DataMember(Name = "repository")]
        public Repository Repository { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}