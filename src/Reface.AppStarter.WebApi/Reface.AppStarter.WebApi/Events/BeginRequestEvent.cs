using Reface.EventBus;
using System.Web;

namespace Reface.AppStarter.WebApi.Events
{
    public class BeginRequestEvent : Event
    {
        public HttpContext HttpContext { get; private set; }

        public BeginRequestEvent(object source,HttpContext httpContext) : base(source)
        {
            this.HttpContext = httpContext;
        }
    }
}
