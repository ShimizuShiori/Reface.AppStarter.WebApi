using Reface.AppStarter.AppContainerBuilders;
using Reface.AppStarter.WebApi.Attributes;
using System.Linq;
using System.Web.Http;

namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 该模块将会把当前模块中所有的 <see cref="ApiController"/> 都注册成为系统的控制器。
    /// </summary>
    [AutoConfigAppModule]
    [ComponentScanAppModule]
    public class WebApiAppModule : AppModule
    {
        public override void OnUsing(AppModuleUsingArguments args)
        {
            var setup = args.AppSetup;
            var targetModule = args.TargetAppModule;
            var controllerBuilder = setup.GetAppContainerBuilder<ControllerAppContainerBuilder>();
            var filterBuilder = setup.GetAppContainerBuilder<AutoFilterAppContainerBuilder>();

            controllerBuilder.RegsiterControllerAssembly(targetModule.GetType().Assembly);

            args.ScannedAttributeAndTypeInfos
                .Where(x => x.Attribute is AutoFilterAttribute)
                .ForEach(x =>
                {
                    filterBuilder.AddFilter(x);
                });
        }
    }
}
