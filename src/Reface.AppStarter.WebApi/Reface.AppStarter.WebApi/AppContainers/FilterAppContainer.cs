using Reface.AppStarter.WebApi;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Reface.AppStarter.AppContainers
{
    public class FilterAppContainer : BaseAppContainer
    {
        private readonly IEnumerable<AutoFilterInfo> autoFilterInfos;

        public FilterAppContainer(IEnumerable<AutoFilterInfo> autoFilterInfos)
        {
            this.autoFilterInfos = autoFilterInfos;
        }

        public override void OnAppStarted(App app)
        {
            GlobalConfiguration.Configuration.Services
                .Replace(typeof(IFilterProvider), new FilterProvider(this.autoFilterInfos));
        }
    }
}
