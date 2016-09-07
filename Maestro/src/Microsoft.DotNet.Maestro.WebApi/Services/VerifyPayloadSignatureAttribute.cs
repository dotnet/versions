// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Microsoft.DotNet.Maestro.WebApi.Services
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class VerifyPayloadSignatureAttribute : FilterAttribute, IAuthorizationFilter
    {
        private const string SignatureHeaderName = "X-Hub-Signature";

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            using (Task<byte[]> getRequestContentTask = actionContext.Request.Content.ReadAsByteArrayAsync())
            {
                try
                {
                    string payloadSignature = GetPayloadSignature(actionContext.Request);
                    string computedHash = ComputeHashHexDigest(await getRequestContentTask);

                    if (!CryptographicEquals(payloadSignature, computedHash))
                    {
                        Trace.TraceWarning("Signature validation failed.  Payload signature: " +
                            $"{payloadSignature}; computed hash: {computedHash}");

                        throw new Exception($"The payload signature specified by the {SignatureHeaderName} " +
                            "header does not match the hash computed from the request.  This could indicate " +
                            "that the repo's Maestro webhook has an incorrect Secret, the request came from " +
                            "an unauthorized source, or the request was corrupted.");
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);

                    actionContext.Response = actionContext.Request.CreateErrorResponse(
                        HttpStatusCode.Unauthorized,
                        ex.Message);
                }
            }

            if (actionContext.Response != null)
            {
                return actionContext.Response;
            }
            else
            {
                return await continuation();
            }
        }

        private string GetPayloadSignature(HttpRequestMessage request)
        {
            IEnumerable<string> headerValues;
            string requestXHubSignature = string.Empty;
            if (request.Headers.TryGetValues(SignatureHeaderName, out headerValues))
            {
                requestXHubSignature = headerValues.FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestXHubSignature) || !requestXHubSignature.StartsWith("sha1="))
            {
                throw new Exception($"The HTTP request does not contain a valid {SignatureHeaderName} " +
                    "header.  Verify that the repo's Maestro webhook is configured with a Secret.");
            }

            return requestXHubSignature.Substring(5).ToUpper();
        }

        private string ComputeHashHexDigest(byte[] requestContent)
        {
            byte[] hmacKey = Encoding.UTF8.GetBytes(Config.Instance.WebhookSecretToken);

            using (HMACSHA1 hmac = new HMACSHA1(hmacKey))
            {
                byte[] computedHash = hmac.ComputeHash(requestContent);
                return BitConverter.ToString(computedHash).Replace("-", string.Empty);
            }
        }

        // Test two strings for equality using a constant-time algorithm such that the execution time varies
        // only on the length of the data, not the contents thereof, to prevent timing attacks. This method
        // assumes that the strings are indexable (as all ASCII strings are).
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static bool CryptographicEquals(string a, string b)
        {
            int result = 0;

            // Short cut if the lengths are not identical
            if (a.Length != b.Length)
            {
                return false;
            }

            unchecked
            {
                // Normally this caching doesn't matter, but with the optimizer off, this nets a non-trivial
                // speedup.
                int aLength = a.Length;

                for (int i = 0; i < aLength; i++)
                    // We use subtraction here instead of XOR because the XOR algorithm gets ever so slightly
                    // faster as more and more differences pile up. This cannot overflow because the output
                    // of subtracting two chars is an int.
                    result = result | (a[i] - b[i]);
            }

            return (0 == result);
        }
    }
}
