using System.Web;

namespace Reface.AppStarter.WebApi
{
    public static class Extensions
    {
        public static App GetApp(this HttpApplicationState application)
        {
            return (App)application.Get(Constant.APPLICATION_ITEM_KEY);
        }
    }
}
