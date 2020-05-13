using Reface.AppStarter.AppContainers;
using Reface.AppStarter.WebApi;
using Reface.AppStarter.WebApi.Attributes;
using System.Collections.Generic;

namespace Reface.AppStarter.AppContainerBuilders
{
    public class AutoFilterAppContainerBuilder : BaseAppContainerBuilder
    {
        private readonly List<AutoFilterInfo> autoFilterInfos = new List<AutoFilterInfo>();

        public void AddFilter(AttributeAndTypeInfo info)
        {
            this.autoFilterInfos.Add(new AutoFilterInfo(info.Type.Assembly, info.Attribute as AutoFilterAttribute, info.Type));
        }

        public override IAppContainer Build(AppSetup setup)
        {
            return new FilterAppContainer(this.autoFilterInfos);
        }
    }
}
