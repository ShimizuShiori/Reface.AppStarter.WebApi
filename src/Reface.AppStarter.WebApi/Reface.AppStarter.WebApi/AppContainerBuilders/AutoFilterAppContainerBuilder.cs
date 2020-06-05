using Reface.AppStarter.AppContainers;
using Reface.AppStarter.WebApi;
using Reface.AppStarter.WebApi.Attributes;
using System.Collections.Generic;

namespace Reface.AppStarter.AppContainerBuilders
{
    /// <summary>
    /// 自动添加的过滤器容器的构建器
    /// </summary>
    public class AutoFilterAppContainerBuilder : BaseAppContainerBuilder
    {
        private readonly List<AutoFilterInfo> autoFilterInfos = new List<AutoFilterInfo>();

        /// <summary>
        /// 添加一个自动添加的过滤器
        /// </summary>
        /// <param name="info"></param>
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
