using Helpers.Services;
using Reface.AppStarter.WebApi;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Helpers.Filters
{
    public class TestFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var work = CurrentWorkAccessor.Get();
            var testService = work.CreateComponent<ITestService>();
            var cnt = actionExecutedContext.Response.Content as ObjectContent<string>;
            cnt.Value = cnt.Value.ToString() + $" Id In Filter = {testService.Id}";
        }
    }
}
