// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Configuration;

namespace Microsoft.DotNet.Maestro
{
    /// <summary>
    /// Holds the configuration information for Maestro.
    /// </summary>
    public class Config
    {
        public static Config Instance { get; } = new Config();

        private Lazy<string> _webhookSecretToken = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(WebhookSecretToken)]);
        private Lazy<string> _vsoUser = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(VSoUser)]);
        private Lazy<string> _vsoPassword = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(VSoPassword)]);
        private Lazy<string> _subscriptionsUrl = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(SubscriptionsUrl)]);
        private Lazy<string> _azureWebJobsStorage = new Lazy<string>(() => ConfigurationManager.ConnectionStrings[nameof(AzureWebJobsStorage)]?.ConnectionString);

        private Config()
        {
        }

        public string WebhookSecretToken
        {
            get { return _webhookSecretToken.Value; }
        }

        public string VSoUser
        {
            get { return _vsoUser.Value; }
        }

        public string VSoPassword
        {
            get { return _vsoPassword.Value; }
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