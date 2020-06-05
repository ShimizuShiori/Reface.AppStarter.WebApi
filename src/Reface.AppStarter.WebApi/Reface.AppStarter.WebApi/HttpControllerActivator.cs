using Reface.AppStarter.WebApi.Events;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Reface.AppStarter.WebApi
{
    /// <summary>
    /// 替换系统内已有的组件。
    /// 它将会从 <see cref="IWork"/> 创建已注入组件的控制器实例。
    /// </summary>
    public class HttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            HttpContext httpContext = HttpContext.Current;
            IWork work = httpContext.GetWork();
            IHttpController controller = work.CreateComponent(controllerType) as IHttpController;
            work.PublishEvent(new ControllerCreatedEvent(this,
                request,
                controllerDescriptor,
                controller));
            return controller;
        }
    }
}
