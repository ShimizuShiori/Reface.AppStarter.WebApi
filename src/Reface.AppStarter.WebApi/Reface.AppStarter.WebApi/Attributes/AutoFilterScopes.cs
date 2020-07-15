namespace Reface.AppStarter.WebApi.Attributes
{
    /// <summary>
    /// 自动拦截器的作用域
    /// </summary>
    public enum AutoFilterScopes
    {
        /// <summary>
        /// 该拦截器只为当前模块有效
        /// </summary>
        AppModule,
        /// <summary>
        /// 该拦截器在整个应用程序内有效
        /// </summary>
        Global
    }
}
