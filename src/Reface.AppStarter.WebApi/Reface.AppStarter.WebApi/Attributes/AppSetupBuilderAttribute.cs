using System;

namespace Reface.AppStarter.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AppSetupBuilderAttribute : Attribute
    {
        public string ConfigPath { get; set; } = "./app.json";

        public virtual AppSetup Build()
        {
            return new AppSetup(this.ConfigPath);
        }
    }
}
