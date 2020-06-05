# 0.4.0
* 更新 Reface.AppStarter 的引用至 0.10.1
* 修改 nuspec 文件，添加依赖项
* 实现原有功能

# 1.0.0
* 更新依赖项 *Reface.AppStarter @ 1.1.0*
* 添加依赖项 *Reface.CommandBus @ 1.1.1*
* 添加依赖项 *Reface.EventBus @ 3.2.0*
* *WebApiAppModule* 改为从 *IAppModule* 继承
* 修改特征名，改为 *ApiRoute(string)*

# 1.1.2
* 添加 *RefaceHttpApplication* 用于简化 *AppSetup* 的启动过程
* 通过事件总线的方式实现对 *ApiPrefix* 的设置
* 简化控制器上 *Attribute* 的名称，改为 *ApiRoute*

# 1.2.0
* 不再使用 *Autofac* 提供的控制器创建器和过滤器注入器
* 使用自实现的 *HttpControllerActivator* 和 *FilterProvider* 实现了在一个请求中，无论是事件总线还是过滤器中得到的组件都位于同一个 *Autofac* 的 *Scope* 中
* 添加事件 *BeginRequestEvent* , *EndRequstEvent* , *ControllerCreatedEvent* 分别表示 **请求开始**，**请求结束** 和 **控制器被创建后**
* 更新 *Reface.AppStarter* 后添加了对 *IWork* 的使用，并将当前请求对应的 *IWork* 挂载在 *HttpContext.Current* 上，开发者可以通过以下两个方法获取 *IWork* 实例
    * *HttpContext.Current.GetWork()*
    * *CurrentWorkAccessor.Get()* [静态方法]
* 添加了自动过滤器，允许两种过滤器作用域：全局和当前模块