using Reface.AppStarter.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Reface.AppStarter.WebApi
{
    public class FilterProvider : IFilterProvider
    {
        private readonly IEnumerable<AutoFilterInfo> autoFilterInfos;

        public FilterProvider(IEnumerable<AutoFilterInfo> autoFilterInfos)
        {
            this.autoFilterInfos = autoFilterInfos;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            List<FilterInfo> result = new List<FilterInfo>();

            Assembly assembly = actionDescriptor.ControllerDescriptor.ControllerType.Assembly;

            result.AddRange(configuration.Filters);

            this.autoFilterInfos.Where(x =>
            {
                var attr = x.AutoFilter;
                return attr.Scope == AutoFilterScopes.Global
                || (attr.Scope == AutoFilterScopes.AppModule && x.Assembly == assembly);
            }).ForEach(x => 
            {
                IFilter filter = Activator.CreateInstance(x.FilterType) as IFilter;
                result.Add(new FilterInfo(filter, FilterScope.Global));
            });

            result.AddRange(actionDescriptor.ControllerDescriptor.GetFilters()
                .Select(f => new FilterInfo(f, FilterScope.Controller)));

            result.AddRange(actionDescriptor.GetFilters().Select(t => new FilterInfo(t, FilterScope.Action)));

            return result;
        }
    }
}
