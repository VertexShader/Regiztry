using System;
using System.Collections.Generic;
using System.Linq;
using NSpec;
using NSpec.Domain;
using NUnit.Framework;
using Regiztry.Controllers;

namespace Regiztry.Tests
{
    //Run the Runnershim with TD.Net to execute all the NSpec tests with NUnit.
    [TestFixture]
    public class RunnerShim
    {
        [Test]
        public void AllTests()
        {
            var finder = new ShimFinder(typeof(RunnerShim).Assembly.GetTypes());

            var builder = new ContextBuilder(finder, new DefaultConventions());

            var runner = new ContextRunner(builder);

            runner.Run();

            if (runner.Failures().Count() != 0)
                Assert.Fail("Some NSpec test failed");
        }
    }

    public class ShimFinder : ISpecFinder
    {
        private Type[] types;

        public ShimFinder(Type[] types)
        {
            this.types = types;
        }

        public IEnumerable<Type> SpecClasses()
        {
            return types;
        }
    }


    public class using_the_home_controller : nspec
    {
        HomeController controller = new HomeController();

        public void when_calling_actions_on_the_controller()
        {
            specify = () => controller.Show().should_not_be_null();
            specify = () => controller.Contact().should_not_be_null();
        }
    }
}
