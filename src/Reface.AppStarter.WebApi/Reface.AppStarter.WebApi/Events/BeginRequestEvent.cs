using Reface.EventBus;
using System.Web;

namespace Reface.AppStarter.WebApi.Events
{
    /// <summary>
    /// 请求开始时的事件
    /// </summary>
    public class BeginRequestEvent : Event
    {
        /// <summary>
        /// Http 上下文
        /// </summary>
        public HttpContext HttpContext { get; private set; }

        public BeginRequestEvent(object source,HttpContext httpContext) : base(source)
        {
            this.HttpContext = httpContext;
        }
    }
}
