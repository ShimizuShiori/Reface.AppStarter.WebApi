using Reface.EventBus;
using System.Web;

namespace Reface.AppStarter.WebApi.Events
{
    public class EndRequestEvent : Event
    {
        public HttpContext HttpContext { get; private set; }
        public EndRequestEvent(object source,HttpContext context) : base(source)
        {
            this.HttpContext = context;
        }
    }
}
