using Reface.AppStarter.Attributes;
using System;

namespace Helpers.Services
{
    public interface ITestService
    {
        Guid Id { get; }
    }

    [Component]
    public class TestService : ITestService
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
