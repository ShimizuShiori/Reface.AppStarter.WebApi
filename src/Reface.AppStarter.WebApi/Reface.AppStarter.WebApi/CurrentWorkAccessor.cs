using System.Web;

namespace Reface.AppStarter.WebApi
{
    public class CurrentWorkAccessor
    {
        public static IWork Get()
        {
            return HttpContext.Current.GetWork();
        }
    }
}
