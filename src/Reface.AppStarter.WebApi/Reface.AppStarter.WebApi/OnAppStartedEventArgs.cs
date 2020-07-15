using System;

namespace Reface.AppStarter.WebApi
{
    /// <summary>
    /// 应用启动后事件参数
    /// </summary>
    public class OnAppStartedEventArgs : EventArgs
    {
        public App App { get; private set; }

        public OnAppStartedEventArgs(App app)
        {
            App = app;
        }
    }
}
