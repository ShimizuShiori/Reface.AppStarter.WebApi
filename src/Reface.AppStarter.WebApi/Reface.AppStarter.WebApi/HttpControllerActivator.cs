using System;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Reface.AppStarter.WebApi
{
    public class HttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            HttpContext httpContext = HttpContext.Current;
            IWork work = httpContext.GetWork();
            return work.CreateComponent(controllerType) as IHttpController;
        }
    }
}
