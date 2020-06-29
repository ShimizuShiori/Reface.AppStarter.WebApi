using Reface.AppStarter.AppModules;
using Reface.AppStarter.WebApi;
using Reface.AppStarter.WebApi.Attributes;
using Reface.AppStarter.WebApi.Events;
using System;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace Reface.AppStarter
{
    /// <summary>
    /// 可以代替原有的 Global.asax 文件的类型。
    /// 通过为你的 Global.asax 类型指定 <see cref="AppSetupBuilderAttribute"/> 特征，你可以重新指定配置文件的路径。
    /// </summary>
    /// <typeparam name="TAppModule">启动项所在的库的 <see cref="AppModule"/> 类型</typeparam>
    public abstract class RefaceHttpApplication<TAppModule> : HttpApplication
        where TAppModule : IAppModule, new()
    {
        public event EventHandler<OnAppStartedEventArgs> AppStarted;
        public event EventHandler<OnAppSetupPreparedEventArgs> AppSetupPrepared;
        public event EventHandler<OnAppSetupBuilderPreparedEventArgs> AppSetupBuilderPrepared;

        public RefaceHttpApplication()
        {
            this.AppSetupBuilderPrepared += RefaceHttpApplication_AppSetupBuilderPrepared;
            this.BeginRequest += RefaceHttpApplication_BeginRequest;
            this.EndRequest += RefaceHttpApplication_EndRequest;
        }

        private void RefaceHttpApplication_EndRequest(object sender, EventArgs e)
        {
            try
            {
                IWork work = CurrentWorkAccessor.Get();
                work.PublishEvent(new EndRequestEvent(this, HttpContext.Current));
                work.Dispose();
            }
            catch (Exception)
            {

            }
        }

        private void RefaceHttpApplication_BeginRequest(object sender, EventArgs e)
        {
            App app = (App)this.Application.GetApp();
            var work = app.BeginWork("HttpRequest");
            work.Context["IsRequest"] = true;
            HttpContext httpContext = HttpContext.Current;
            httpContext.Items["WORK"] = work;
            work.PublishEvent(new BeginRequestEvent(this, httpContext));
        }

        private void RefaceHttpApplication_AppSetupBuilderPrepared(object sender, OnAppSetupBuilderPreparedEventArgs e)
        {
            e.AppSetupBuilder.ConfigPath = this.Server.MapPath(e.AppSetupBuilder.ConfigPath);
        }

        protected void Application_Start()
        {

            AppSetupBuilderAttribute builder = this.GetType().GetCustomAttribute<AppSetupBuilderAttribute>();
            if (builder == null) builder = new AppSetupBuilderAttribute();
            this.AppSetupBuilderPrepared?.Invoke(this, new OnAppSetupBuilderPreparedEventArgs(builder));

            AppSetup appSetup = builder.Build();
            appSetup.AppContext[Constant.APP_CONTEXT_KEY_ENV] = Constant.ENV_WEBAPI;

            TAppModule webAppModule = new TAppModule();
            this.AppSetupPrepared?.Invoke(this, new OnAppSetupPreparedEventArgs(appSetup));
            var app = appSetup.Start(webAppModule);

            this.AppStarted?.Invoke(this, new OnAppStartedEventArgs(app));
            this.Application.Set(Constant.APPLICATION_ITEM_KEY, app);


        }
    }
}
