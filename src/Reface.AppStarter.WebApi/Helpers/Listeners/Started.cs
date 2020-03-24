using Reface.AppStarter.Attributes;
using Reface.AppStarter.Events;
using Reface.EventBus;
using System.Diagnostics;

namespace Helpers.Listeners
{
    [Listener]
    public class Started : IEventListener<AppStartedEvent>
    {
        public void Handle(AppStartedEvent @event)
        {
            Debug.WriteLine("Helpers.Started");
        }
    }
}
