using System.Web;

namespace Reface.AppStarter.WebApi
{
    /// <summary>
    /// 获取当前 <see cref="IWork"/> 实例的组件
    /// </summary>
    public class CurrentWorkAccessor
    {
        public static IWork Get()
        {
            return HttpContext.Current.GetWork();
        }
    }
}
