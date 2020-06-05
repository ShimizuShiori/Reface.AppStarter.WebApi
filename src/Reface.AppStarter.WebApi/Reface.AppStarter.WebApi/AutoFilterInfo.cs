using Reface.AppStarter.WebApi.Attributes;
using System;
using System.Reflection;

namespace Reface.AppStarter.WebApi
{
    public class AutoFilterInfo
    {
        public AutoFilterAttribute AutoFilter { get; private set; }
        public Assembly Assembly { get; private set; }
        public Type FilterType { get; private set; }

        public AutoFilterInfo(Assembly assembly, AutoFilterAttribute autoFilter, Type filterType)
        {
            this.AutoFilter = autoFilter;
            this.FilterType = filterType;
            this.Assembly = assembly;
        }
    }
}
