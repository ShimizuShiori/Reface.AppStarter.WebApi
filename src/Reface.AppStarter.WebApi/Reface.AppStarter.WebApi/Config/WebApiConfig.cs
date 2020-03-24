using Reface.AppStarter.Attributes;

namespace Reface.AppStarter.Config
{
    [Config("WebApi")]
    public class WebApiConfig
    {
        public string Prefix { get; set; } = "api";
    }
}
