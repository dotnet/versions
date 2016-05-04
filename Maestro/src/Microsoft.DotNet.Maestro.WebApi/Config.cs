using System;
using System.Configuration;

namespace Microsoft.DotNet.Maestro.WebApi
{
    /// <summary>
    /// Holds the configuration information for Maestro.
    /// </summary>
    public class Config
    {
        public static Config Instance { get; } = new Config();

        private Lazy<string> _vsoUser = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(VSoUser)]);
        private Lazy<string> _vsoPassword = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(VSoPassword)]);
        private Lazy<string> _subscriptionsUrl = new Lazy<string>(() => ConfigurationManager.AppSettings[nameof(SubscriptionsUrl)]);

        private Config()
        {
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
    }
}