using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    public static class VsoParameterGenerator
    {
        public static string GetParameters(IDictionary<string, JToken> vsoParameters)
        {
            if (vsoParameters == null || !vsoParameters.Any())
            {
                return null;
            }

            JObject parameterObject = new JObject();
            foreach (KeyValuePair<string, JToken> parameter in vsoParameters)
            {
                string value = GetValueString(parameter.Value);

                parameterObject[parameter.Key] = value;
            }

            return parameterObject.ToString();
        }

        private static string GetValueString(JToken value)
        {
            if (value.Type == JTokenType.Array)
            {
                JArray array = (JArray)value;
                return string.Join(" ", array.Values());
            }
            else
            {
                return value.ToString();
            }
        }
    }
}