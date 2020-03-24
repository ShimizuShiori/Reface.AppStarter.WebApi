using Reface.AppStarter.Attributes;

namespace Helpers.Services
{
    [Component]
    public class ChineseLangService : ILangService
    {
        public string T(string text)
        {
            switch (text)
            {
                case Constant.TEXT_SHOW_HELP:
                    return "此处为帮助信息";
                default:
                    return "无消息";
            }
        }
    }
}
