using Reface.AppStarter.AppModules;
using Reface.AppStarter.WebApi;
using System.Web;

namespace Reface.AppStarter
{
    /// <summary>
    /// 可以代替原有的 Global.asax 文件的类型。
    /// 你可以通过调用父类的函数函数重新指定配置文件的路径。
    /// </summary>
    /// <typeparam name="TAppModule">启动项所在的库的 <see cref="AppModule"/> 类型</typeparam>
    public class RefaceHttpApplication<TAppModule> : HttpApplication
        where TAppModule : IAppModule, new()
    {
        private readonly string jsonPath;

        public RefaceHttpApplication(string jsonPath = "./app.json")
        {
            this.jsonPath = jsonPath;
        }

        protected void Application_Start()
        {
            string appJsonPath = this.Server.MapPath(this.jsonPath);
            AppSetup appSetup = new AppSetup(appJsonPath);
            TAppModule webAppModule = new TAppModule();
            var app = appSetup.Start(webAppModule);
            this.Application.Set(Constant.APPLICATION_ITEM_KEY, app);
        }
    }
}
