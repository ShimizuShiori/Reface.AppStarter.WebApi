using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reface.AppStarter.WebApi
{
    public class OnAppSetupPreparedEventArgs : EventArgs
    {
        public AppSetup AppSetup { get; private set; }

        public OnAppSetupPreparedEventArgs(AppSetup appSetup)
        {
            AppSetup = appSetup;
        }
    }
}
