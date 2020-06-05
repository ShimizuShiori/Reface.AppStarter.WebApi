using System.Web.Http;

namespace Reface.AppStarter
{
    class WebApiRouterSetup
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}
