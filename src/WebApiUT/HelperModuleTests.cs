using Helpers.Controllers;
using Helpers.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reface.AppStarter;
using WebApiUT.AppModules;

namespace WebApiUT
{
    [TestClass]
    public class HelperModuleTests
    {
        [TestMethod]
        public void AppSetupStart()
        {
            var app = AppSetup.Start<TestAppModule>();
        }

        [TestMethod]
        public void LangServiceIsNotNull()
        {
            var app = AppSetup.Start<TestAppModule>();
            using (var work = app.BeginWork(""))
            {
                var service = work.CreateComponent<ILangService>();
                Assert.IsNotNull(service);
            }
        }

        [TestMethod]
        public void GetIdController()
        {
            var app = AppSetup.Start<TestAppModule>();
            using (var work = app.BeginWork(""))
            {
                var controller = work.CreateComponent<IdController>();
                Assert.IsNotNull(controller);
            }
        }
    }
}
