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