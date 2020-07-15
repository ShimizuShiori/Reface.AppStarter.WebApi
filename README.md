# Reface.AppStarter.WebApi

# 简介

这是一个基于 *Reface.AppStarter* 设计的开箱即用的 *WebApi* [模块][AppModule]。

该 [模块][AppModule] 提供以下功能

* 简化 *WebApi* 项目的配置
* 允许将 *ApiController* 放置在不同的 *Library* 中，并在系统启动时，将所有的 *ApiController* 启用
* 作为 [*Reface.AppStarter*][AppModule] 的一个模块，*ApiController* 中的依赖项自动注入
* 通过 *Reface.AppStarter.AutoConfigAppModule* 功能配置全局的 *WebApi Url Prefix*
* 自定义的 *ApiRoute* 可以应用 *Reface.AppStarter.Config.WebApiConfig* 中的 *WebApi Url Prefix* 
* 提供模块内和全局内的拦截器定义
* 利用事件总线监听 **请求开始** 、 **请求结束** 、 **控制器创建** 事件

[AppModule]: https://github.com/ShimizuShiori/Reface.AppStarter

# 依赖项

* *Autofac.WebApi2*
* *Microsoft.AspNet.WebApi*
* *Reface.AppStarter*

# Nuget 地址

https://www.nuget.org/packages/Reface.AppStarter.WebApi

# 使用方法

## 1 开发 *ApiController* 的模块

你可以将你的 *ApiController* 根据不同的业务功能放在不同的 *Library* 中。

这些 *ApiController* 都需要依赖 *Reface.AppStarter.WebApi*

你需要为每一个 *Library* 创建一个 *AppModule* 让它们成为一个 **模块**。并为这些 *AppModule* 添加 *WebApiAppModule*

```csharp
// UsersAppModule.cs
[WebApiAppModule]
[ComponentScanAppModule]
[AutoConfigAppModule]
public class UsersAppModule : AppModule
{
}
```

```csharp
/// OrdersAppModule.cs
[WebApiAppModule]
[ComponentScanAppModule]
[AutoConfigAppModule]
public class OrdersAppModule : AppModule
{
}
```

```csharp
/// StockAppModule.cs
[WebApiAppModule]
[ComponentScanAppModule]
[AutoConfigAppModule]
public class StockAppModule : AppModule
{
}
```

**开发控制器**

控制器与原开发模式相同，唯一的改动是控制器上的 *Route* 改为 *ApiRoute*
```csharp
[ApiRoute("help")]
public class HelpController : ApiController
{
    
}
```

## 2 开发 *WebApi* 启动项

创建你的 *WebApi* 启动项目，与平时创建 *WebApi* 项目的过程相同。

让你的 *WebApi* 启动项依赖 *Reface.AppStarter* 。

创建 *WebApi* 启动项的 *AppModule*

> 在 *Reface.AppStarted* 中，所有的 *Library* 都应当有一个 *AppModule*

让你的 *AppModule* 依赖其它 *AppModule*

```csharp
[UsersAppModule]
[OrdersAppModule]
[StockAppModule]
public class MyWebApiAppModule : AppModule
{

}
```

最后一步，创建 *Global.asax* ( 全局应用程序类 ) ，让其继承于 *RefaceHttpApplication&lt;MyWebApiAppModule>*

> MyWebApiAppModule，就是你的 *WebApi* 启动项的 *AppModule* 类型。

你可以编写构造函数，向父类传递 *Reface.AppStarter* 的配置文件路径，默认是从 *WebApi* 启动项所在目录中的 *app.json* 中加载。

## 3 事件总线

* *BeginRequestEvent* 请求发起时
* *EndRequestEvent* 请求结束时
* *ControllerCreatedEvent* 控制器创建后

## 4 添加拦截器

继承 *ActionFilterAttribute* 类型，并添加 *AutoFilter* 即可自动注册成为拦截器（不用显式的添加到控制器上）