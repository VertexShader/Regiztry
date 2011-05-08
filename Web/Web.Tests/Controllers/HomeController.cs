using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;

namespace Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void home_should_show_contact_information_page()
        {
            var controller = new HomeController();
            var result = controller.Contact();
            Assert.IsNotNull(result);
        }

        [Test]
        public void home_should_show_the_main_site_home_page()
        {
            var controller = new HomeController();
            var result = controller.Index();
            Assert.IsNotNull(result);
        }


    }
}
