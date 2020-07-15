using System;
using System.Web.Http;
using Reface.AppStarter.Configs;

namespace Reface.AppStarter.WebApi.Attributes
{
    /// <summary>
    /// Api 的路由，
    /// 使用此特征定义路由，可以将 <see cref="WebApiConfig.Prefix"/> 中的值作为前缀
    /// </summary>
    public class ApiRouteAttribute : RoutePrefixAttribute
    {
        private static string globalPrefix = "api";

        /// <summary>
        /// 设置全局的路由前缀，该方法应当在系统启动阶段调用
        /// </summary>
        /// <param name="prefix"></param>
        public static void SetGolbalPrefix(string prefix)
        {
            ApiRouteAttribute.globalPrefix = prefix;
        }

        /// <summary>
        /// 前缀，不需要用斜线开头。
        /// </summary>
        /// <param name="prefix"></param>
        public ApiRouteAttribute(string prefix)
            : base(globalPrefix + "/" + prefix)
        {
        }
    }
}
