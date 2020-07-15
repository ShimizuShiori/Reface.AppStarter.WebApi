using System;

namespace Reface.AppStarter.WebApi.Attributes
{
    /// <summary>
    /// 将该特征标记在 <see cref="RefaceHttpApplication{TAppModule}"/> 的子类上，可以自定义 <see cref="AppSetup"/> 实例的创建过程。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AppSetupBuilderAttribute : Attribute
    {
        /// <summary>
        /// 指定的配置文件路径
        /// </summary>
        public string ConfigPath { get; set; } = "./app.json";

        public virtual AppSetup Build()
        {
            return new AppSetup(this.ConfigPath);
        }
    }
}
