using Reface.AppStarter.Attributes;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [ApiRoute("[controller]")]
    public class HelloController : ApiController
    {
        [Route]
        public string Get()
        {
            return "HelloWorld!";
        }
    }
}
