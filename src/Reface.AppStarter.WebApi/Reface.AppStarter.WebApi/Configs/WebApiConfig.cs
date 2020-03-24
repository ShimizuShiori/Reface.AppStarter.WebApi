using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Configs
{
    [Config("WebApi")]
    public class WebApiConfig
    {
        public string Prefix { get; set; } = "api";
    }
}
