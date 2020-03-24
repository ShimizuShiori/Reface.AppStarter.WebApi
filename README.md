# Reface.AppStarter.WebApi

# 简介

这是一个基于 *Reface.AppStarter* 和 *Autofac.WebApi2* 设计的开箱即用的 *WebApi* [模块][AppModule]。

该 [模块][AppModule] 提供以下功能

* 简化 *WebApi* 项目的配置
* 允许将 *ApiController* 放置在不同的 *Library* 中，并在系统启动时，将所有的 *ApiController* 启用
* 作为 [*Reface.AppStarter*][AppModule] 的一个模块，*ApiController* 中的依赖项自动注入
* 通过 *Reface.AppStarter.AutoConfigAppModule* 功能配置全局的 *WebApi Url Prefix*
* 自定义的 *ApiRoute* 可以应用 *Reface.AppStarter.Config.WebApiConfig* 中的 *WebApi Url Prefix* 

[AppModule]: https://github.com/ShimizuShiori/Reface.AppStarter