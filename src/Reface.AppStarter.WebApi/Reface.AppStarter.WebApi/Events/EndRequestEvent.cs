using Reface.EventBus;
using System.Web;

namespace Reface.AppStarter.WebApi.Events
{
    /// <summary>
    /// 请求结束时的事件
    /// </summary>
    public class EndRequestEvent : Event
    {
        /// <summary>
        /// Http 上下文
        /// </summary>
        public HttpContext HttpContext { get; private set; }
        public EndRequestEvent(object source,HttpContext context) : base(source)
        {
            this.HttpContext = context;
        }
    }
}
