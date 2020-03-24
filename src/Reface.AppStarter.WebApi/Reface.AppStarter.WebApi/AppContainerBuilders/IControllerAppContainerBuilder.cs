using Reface.AppStarter.AppContainerBuilders;
using System.Reflection;

namespace Reface.AppStarter.AppContainerBuilders
{
    public interface IControllerAppContainerBuilder : IAppContainerBuilder
    {
        void RegsiterControllerAssembly(Assembly assembly);
    }
}