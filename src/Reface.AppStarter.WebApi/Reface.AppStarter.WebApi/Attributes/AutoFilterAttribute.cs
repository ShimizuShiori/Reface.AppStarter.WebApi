using Reface.AppStarter.Attributes;
using System;

namespace Reface.AppStarter.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoFilterAttribute : ScannableAttribute
    {
        public AutoFilterScopes Scope { get; private set; }

        public AutoFilterAttribute(AutoFilterScopes scope)
        {
            Scope = scope;
        }
    }
}
