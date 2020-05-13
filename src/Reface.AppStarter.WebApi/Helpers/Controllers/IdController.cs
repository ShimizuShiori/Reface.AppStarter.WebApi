using Helpers.Filters;
using Helpers.Services;
using Reface.AppStarter;
using Reface.AppStarter.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace Helpers.Controllers
{
    [Test2Filter]
    [ApiRoute("id")]
    public class IdController : ApiController
    {
        private readonly IWork work;
        private readonly ITestService testService;

        public IdController(IWork work, ITestService testService)
        {
            this.work = work;
            this.testService = testService;
        }

        [TestFilter]
        [Route]
        [HttpGet]
        public string Post()
        {
            return $"Id = {testService.Id} " +
                $"Id in Context = {HttpContext.Current.Items["ID"]}";
        }

        [HttpGet]
        [Route("services")]
        public List<Type> ServiceTypes()
        {
            List<Type> result = new List<Type>();
            var ss = GlobalConfiguration.Configuration.Services;
            return result;
        }
    }
}
