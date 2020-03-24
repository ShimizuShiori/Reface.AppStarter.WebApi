using Reface.AppStarter.Attributes;
using Reface.AppStarter.Configs;
using Reface.AppStarter.Events;
using Reface.AppStarter.WebApi.Attributes;
using Reface.EventBus;

namespace Reface.AppStarter.WebApi.Listeners
{
    [Listener]
    public class SetGolbalPrefixOnAppStarted : IEventListener<AppStartedEvent>
    {
        private readonly WebApiConfig webApiConfig;

        public SetGolbalPrefixOnAppStarted(WebApiConfig webApiConfig)
        {
            this.webApiConfig = webApiConfig;
        }

        public void Handle(AppStartedEvent @event)
        {
            ApiRouteAttribute.SetGolbalPrefix(webApiConfig.Prefix);
        }
    }
}
