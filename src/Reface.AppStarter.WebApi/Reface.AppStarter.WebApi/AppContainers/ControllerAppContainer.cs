﻿using Reface.AppStarter.WebApi;
using System.Web.Http;
using System.Web.Http.Dispatcher;

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

            HttpConfiguration configuration = GlobalConfiguration.Configuration;

            GlobalConfiguration.Configure(WebApiRouterSetup.Register);
            GlobalConfiguration.Configuration.Services
                .Replace(typeof(IHttpControllerActivator), new HttpControllerActivator());
        }
    }
}
