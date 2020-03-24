using Reface.AppStarter.AppContainerBuilders;
using Reface.AppStarter.AppModules;

namespace Reface.AppStarter
{
    [AutoConfigAppModule]
    public class WebApiAppModule : AppModule
    {
        public override void OnUsing(AppSetup setup, IAppModule targetModule)
        {
            var builder = setup.GetAppContainerBuilder<ControllerAppContainerBuilder>();
            builder.RegsiterControllerAssembly(targetModule.GetType().Assembly);
        }
    }
}
