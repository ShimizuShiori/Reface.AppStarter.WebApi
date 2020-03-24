using Helpers.Services;
using Reface.AppStarter.WebApi.Attributes;
using System.Web.Http;

namespace Helpers.Controllers
{
    [ApiRoute("help")]
    public class HelpController : ApiController
    {
        private readonly ILangService langService;

        public HelpController(ILangService langService)
        {
            this.langService = langService;
        }

        [Route]
        public string Get()
        {
            return this.langService.T(Constant.TEXT_SHOW_HELP);
        }
    }
}
