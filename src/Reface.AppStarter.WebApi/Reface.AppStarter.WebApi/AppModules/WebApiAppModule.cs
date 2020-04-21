using Reface.AppStarter.AppContainerBuilders;
using System.Web.Http;

namespace Reface.AppStarter.AppModules
{
    /// <summary>
    /// 使用此模块，将会把当前模块中所有的 <see cref="ApiController"/> 都注册成为系统的控制器。
    /// </summary>
    [AutoConfigAppModule]
    [ComponentScanAppModule]
    public class WebApiAppModule : AppModule
    {
        public override void OnUsing(AppModuleUsingArguments args)
        {
            var setup = args.AppSetup;
            var targetModule = args.TargetAppModule;
            var builder = setup.GetAppContainerBuilder<ControllerAppContainerBuilder>();
            builder.RegsiterControllerAssembly(targetModule.GetType().Assembly);
        }
    }
}
