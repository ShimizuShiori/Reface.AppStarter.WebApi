using Reface.AppStarter.WebApi;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Reface.AppStarter.AppContainers
{
    /// <summary>
    /// 控制器容器
    /// </summary>
    public class ControllerAppContainer : IControllerAppContainer
    {
        public void Dispose()
        {
        }

        public void OnAppPrepair(App app)
        {
        }

        public void OnAppStarted(App app)
        {
            if (!app.EnvIsWebApi())
                return;

            HttpConfiguration configuration = GlobalConfiguration.Configuration;
            GlobalConfiguration.Configure(WebApiRouterSetup.Register);
            GlobalConfiguration.Configuration.Services
                .Replace(typeof(IHttpControllerActivator), new HttpControllerActivator());
        }
    }
}
