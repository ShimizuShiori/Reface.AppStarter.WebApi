using System.Web;

namespace Reface.AppStarter.WebApi
{
    public static class Extensions
    {
        public static App GetApp(this HttpApplicationState application)
        {
            return (App)application.Get(Constant.APPLICATION_ITEM_KEY);
        }

        public static IWork GetWork(this HttpContext httpContext)
        {
            return (IWork)httpContext.Items["WORK"];
        }
        public static bool EnvIsWebApi(this App app)
        {
            return app.Context.GetOrCreate(Constant.APP_CONTEXT_KEY_ENV, key => "") == Constant.ENV_WEBAPI;
        }
    }
}
