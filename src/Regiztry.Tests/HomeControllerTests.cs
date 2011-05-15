﻿using NUnit.Framework;
using Regiztry.Controllers;

namespace Regiztry.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void should_display_home_page()
        {
            var controller = new HomeController();
            Assert.IsNotNull(controller.Show());
        }

        [Test]
        public void should_display_contacts_page()
        {
            var controller = new HomeController();
            Assert.IsNotNull(controller.Contact());
        }
    }
}
