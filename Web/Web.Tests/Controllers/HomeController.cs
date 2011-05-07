using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;

namespace Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_Always_DirectsToIndexView()
        {
            var controller = new HomeController();

            var result = controller.Index();
            var vResult = result as ViewResult;

            Assert.True(vResult != null, "controller result should be  a ViewResult");
            Assert.True(vResult.ViewName == string.Empty || vResult.ViewName == "Index", "view result should point to Index, but points to " + vResult.ViewName);
        }
    }
}
