// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Microsoft.DotNet.Maestro.Services
{
    public static class VsoParameterGenerator
    {
        public static string GetParameters(IDictionary<string, JToken> vsoParameters, Func<string, bool> filter)
        {
            if (vsoParameters == null || !vsoParameters.Any())
            {
                return null;
            }

            JObject parameterObject = new JObject();
            foreach (KeyValuePair<string, JToken> parameter in vsoParameters)
            {
                if (filter(parameter.Key))
                {
                    string value = GetValueString(parameter.Value);

                    parameterObject[parameter.Key] = value;
                }
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