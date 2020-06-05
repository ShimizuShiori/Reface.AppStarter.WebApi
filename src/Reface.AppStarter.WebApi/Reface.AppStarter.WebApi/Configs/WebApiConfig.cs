using Reface.AppStarter.Attributes;
using System.ComponentModel;

namespace Reface.AppStarter.Configs
{
    /// <summary>
    /// WebApi 模块的配置文件
    /// </summary>
    [Config("WebApi")]
    public class WebApiConfig
    {
        [Description("WebApi 的前缀，默认值是 api")]
        public string Prefix { get; set; } = "api";
    }
}
