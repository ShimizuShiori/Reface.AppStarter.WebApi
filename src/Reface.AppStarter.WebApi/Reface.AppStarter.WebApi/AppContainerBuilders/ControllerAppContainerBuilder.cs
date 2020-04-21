using Autofac;
using Autofac.Integration.WebApi;
using Reface.AppStarter.AppContainers;
using System.Collections.Generic;
using System.Reflection;

namespace Reface.AppStarter.AppContainerBuilders
{
    public class ControllerAppContainerBuilder : IAppContainerBuilder
    {
        private readonly List<Assembly> assemblies
            = new List<Assembly>();

        public void RegsiterControllerAssembly(Assembly assembly)
        {
            this.assemblies.Add(assembly);
        }

        public IAppContainer Build(AppSetup setup)
        {
            return new ControllerAppContainer();
        }

        public void Prepare(AppSetup setup)
        {
            AutofacContainerBuilder autofacContainerBuilder = setup.GetAppContainerBuilder<AutofacContainerBuilder>();
            autofacContainerBuilder.Building += AutofacContainerBuilder_Building;
        }

        private void AutofacContainerBuilder_Building(object sender, AppContainerBuilderBuildEventArgs e)
        {
            AutofacContainerBuilder autofacContainerBuilder = (AutofacContainerBuilder)sender;
            ContainerBuilder containerBuilder = autofacContainerBuilder.AutofacContainerBuilderInstance;
            this.assemblies.ForEach(x =>
            {
                containerBuilder.RegisterApiControllers(x);
            });
        }
    }
}
