using System.Web;
using System.Web.Http;

namespace Microsoft.DotNet.Maestro.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
