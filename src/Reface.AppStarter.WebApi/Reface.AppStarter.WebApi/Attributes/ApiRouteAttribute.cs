using System;
using System.Web.Http;

namespace Reface.AppStarter.WebApi.Attributes
{
    /// <summary>
    /// Api 的路由，
    /// 使用此特征定义路由，可以将 <see cref="Reface.AppStarter.Config.WebApiConfig.Prefix"/> 中的值加入
    /// </summary>
    public class ApiRouteAttribute : RoutePrefixAttribute
    {
        private static string globalPrefix = "api";

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
