using Autofac.Integration.WebApi;
using Reface.AppStarter.Configs;
using Reface.AppStarter.WebApi.Attributes;
using System.Web.Http;

namespace Reface.AppStarter.AppContainers
{
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
            IComponentContainer componentContainer = app.GetAppContainer<IComponentContainer>();
            //WebApiConfig webApiConfig = componentContainer.CreateComponent<WebApiConfig>();
            //ApiRouteAttribute.SetGolbalPrefix(webApiConfig.Prefix);

            if (componentContainer is AutofacContainerComponentContainer autofac)
            {
                HttpConfiguration configuration = GlobalConfiguration.Configuration;
                if (!(configuration.DependencyResolver is AutofacWebApiDependencyResolver))
                {
                    GlobalConfiguration.Configure(WebApiRouterSetup.Register);
                    configuration.DependencyResolver = new AutofacWebApiDependencyResolver(autofac.Container);
                }
            }

        }
    }
}
