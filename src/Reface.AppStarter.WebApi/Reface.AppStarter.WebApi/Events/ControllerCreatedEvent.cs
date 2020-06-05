using Reface.EventBus;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace Reface.AppStarter.WebApi.Events
{
    /// <summary>
    /// 当一个控制器被创建后的事件
    /// </summary>
    public class ControllerCreatedEvent : Event
    {
        public HttpRequestMessage Request { get; private set; }
        public HttpControllerDescriptor ControllerDescriptor { get; private set; }
        public IHttpController Controller { get; private set; }

        public ControllerCreatedEvent(object source,
            HttpRequestMessage request,
            HttpControllerDescriptor descriptor,
            IHttpController controller) : base(source)
        {
            this.Request = request;
            this.ControllerDescriptor = descriptor;
            this.Controller = controller;
        }
    }
}
