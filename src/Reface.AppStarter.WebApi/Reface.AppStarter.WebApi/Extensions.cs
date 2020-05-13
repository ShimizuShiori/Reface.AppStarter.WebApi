using System.Web;
using System.Web.Http.Filters;

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
    }
}
