using Reface.AppStarter.AppContainerBuilders;

namespace Reface.AppStarter.AppModules
{
    [AutoConfigAppModule]
    [ComponentScanAppModule]
    public class WebApiAppModule : AppModule
    {
        public override void OnUsing(AppSetup setup, IAppModule targetModule)
        {
            var builder = setup.GetAppContainerBuilder<ControllerAppContainerBuilder>();
            builder.RegsiterControllerAssembly(targetModule.GetType().Assembly);
        }
    }
}
