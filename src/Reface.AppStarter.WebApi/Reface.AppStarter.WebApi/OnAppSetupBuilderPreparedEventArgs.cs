using Reface.AppStarter.WebApi.Attributes;
using System;

namespace Reface.AppStarter.WebApi
{
    public class OnAppSetupBuilderPreparedEventArgs : EventArgs
    {
        public AppSetupBuilderAttribute AppSetupBuilder { get; private set; }

        public OnAppSetupBuilderPreparedEventArgs(AppSetupBuilderAttribute appSetupBuilder)
        {
            AppSetupBuilder = appSetupBuilder;
        }
    }
}
