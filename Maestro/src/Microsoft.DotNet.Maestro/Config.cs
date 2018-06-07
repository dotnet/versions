// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Configuration;
using System.Collections.Concurrent;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using System.Diagnostics;

namespace Microsoft.DotNet.Maestro
{
    /// <summary>
    /// Holds the configuration information for Maestro.
    /// </summary>
    public class Config
    {
        public static Config Instance { get; } = new Config();

        private Lazy<string> _webhookSecretToken = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(WebhookSecretToken)]);
        private Lazy<string> _subscriptionsUrl = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(SubscriptionsUrl)]);
        private Lazy<string> _azureWebJobsStorage = new Lazy<string>(() => ConfigurationManager.ConnectionStrings[nameof(AzureWebJobsStorage)]?.ConnectionString);
        private Lazy<string> _vstsInstanceUserName = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(VstsUsername)]);
        private ConcurrentDictionary<string, string> _vstsCreds = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private Config()
        {
            
        }

        public string WebhookSecretToken
        {
            get { return _webhookSecretToken.Value; }
        }

        public string VstsUsername
        {
            get { return _vstsInstanceUserName.Value; }
        }

        public string GetPassword(string instance)
        {
            string currentPassword;
            if (_vstsCreds.TryGetValue(instance, out currentPassword))
            {
                return currentPassword;
            }
            else
            {
                // Grab the secret name from the web.config.  Keys are case insensitive
                string secretName = ConfigurationManager.AppSettings[$"{instance}-KeyVaultSecretName"];
                if (string.IsNullOrEmpty(secretName))
                {
                    Trace.TraceError($"Could not locate a secret name for {instance} VSTS instance (looked up config key {instance}-KeyVaultSecretName)");
                    throw new Exception($"Could not locate a secret name for {instance} VSTS instance (looked up config key {instance}-KeyVaultSecretName)");
                }

                AzureServiceTokenProvider tokenProvider = new AzureServiceTokenProvider();
                try
                {
                    KeyVaultClient client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback));
                    var secret = client.GetSecretAsync(secretName).ConfigureAwait(false).GetAwaiter().GetResult();
                    _vstsCreds.TryAdd(instance, secret.Value);
                    return secret.Value;
                }
                catch (Exception e)
                {
                    Trace.TraceError($"Failed to obtain password for instance {instance}.  Check that the application has permissions to the required keyvault.\n{e.ToString()}");
                    throw new Exception($"Failed to obtain password for instance {instance}", e);
                }
            }
        }

        public string SubscriptionsUrl
        {
            get { return _subscriptionsUrl.Value; }
        }

        public string AzureWebJobsStorage
        {
            get { return _azureWebJobsStorage.Value; }
        }
    }
}