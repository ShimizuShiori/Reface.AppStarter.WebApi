using Reface.AppStarter.Attributes;
using System;

namespace Reface.AppStarter.WebApi.Attributes
{
    /// <summary>
    /// 自动装配的拦截器，不需要将该拦截器定义到控制器上
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoFilterAttribute : ScannableAttribute
    {
        /// <summary>
        /// 拦截器的工作范围
        /// </summary>
        public AutoFilterScopes Scope { get; private set; }

        public AutoFilterAttribute(AutoFilterScopes scope)
        {
            Scope = scope;
        }
    }
}
