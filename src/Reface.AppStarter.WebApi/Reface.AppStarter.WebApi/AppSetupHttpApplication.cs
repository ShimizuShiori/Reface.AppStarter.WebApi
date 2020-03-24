﻿using Reface.AppStarter.AppModules;
using System.Web;

namespace Reface.AppStarter
{
    public class AppSetupHttpApplication<TAppModule> : HttpApplication
        where TAppModule : IAppModule, new()
    {
        private readonly string jsonPath;

        public AppSetupHttpApplication(string jsonPath = "./app.json")
        {
            this.jsonPath = jsonPath;
        }

        protected void Application_Start()
        {
            string appJsonPath = this.Server.MapPath(this.jsonPath);
            AppSetup appSetup = new AppSetup(appJsonPath);
            TAppModule webAppModule = new TAppModule();
            appSetup.Start(webAppModule);
        }
    }
}
