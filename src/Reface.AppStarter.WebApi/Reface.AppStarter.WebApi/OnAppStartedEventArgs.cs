using System;

namespace Reface.AppStarter.WebApi
{
    public class OnAppStartedEventArgs : EventArgs
    {
        public App App { get; private set; }

        public OnAppStartedEventArgs(App app)
        {
            App = app;
        }
    }
}
