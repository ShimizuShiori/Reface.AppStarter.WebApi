using Reface.AppStarter.WebApi.Attributes;
using System.Web.Http.Filters;

namespace Helpers.Filters
{
    [AutoFilter(AutoFilterScopes.AppModule)]
    public class AllFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            int i = 0;
        }
    }
}
