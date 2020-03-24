using Reface.AppStarter.WebApi.Attributes;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [ApiRoute("hello")]
    public class HelloController : ApiController
    {
        [Route]
        public string Get()
        {
            return "HelloWorld!";
        }
    }
}
