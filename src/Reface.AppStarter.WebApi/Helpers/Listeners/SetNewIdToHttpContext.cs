using Helpers.Services;
using Reface.AppStarter.Attributes;
using Reface.AppStarter.WebApi.Events;
using Reface.EventBus;

namespace Helpers.Listeners
{
    [Listener]
    public class SetNewIdToHttpContext : IEventListener<BeginRequestEvent>
    {
        private readonly ITestService testService;

        public SetNewIdToHttpContext(ITestService testService)
        {
            this.testService = testService;
        }

        public void Handle(BeginRequestEvent @event)
        {
            @event.HttpContext.Items.Add("ID", this.testService.Id);
        }
    }
}
