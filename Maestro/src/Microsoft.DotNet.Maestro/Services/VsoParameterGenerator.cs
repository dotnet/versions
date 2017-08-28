// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.Maestro.Services
{
    public static class VsoParameterGenerator
    {
        public static string GetParameters(IDictionary<string, JToken> actionArguments, IDictionary<string, string> parameterSubstitutions)
        {
            JToken vsoBuildParametersToken = null;
            actionArguments?.TryGetValue("vsoBuildParameters", out vsoBuildParametersToken);

            if (vsoBuildParametersToken == null)
            {
                return null;
            }

            JObject parameterObject = (JObject)vsoBuildParametersToken;
            foreach (KeyValuePair<string, JToken> parameter in parameterObject)
            {
                string value = GetValueString(parameter.Value);

                if (parameterSubstitutions != null)
                {
                    foreach (var sub in parameterSubstitutions)
                    {
                        value = value.Replace(sub.Key, sub.Value);
                    }
                }

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