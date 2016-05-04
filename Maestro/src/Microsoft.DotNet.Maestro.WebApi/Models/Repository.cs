using System.Runtime.Serialization;

namespace Microsoft.DotNet.Maestro.WebApi.Models
{
    public class Repository
    {
        [DataMember(Name = "full_name")]
        public string Full_Name { get; set; }
    }
}