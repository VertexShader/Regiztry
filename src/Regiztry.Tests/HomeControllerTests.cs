//using System;
//using System.Collections.Generic;
//using System.Linq;
//using NSpec;
//using NSpec.Domain;
//using NUnit.Framework;
//using Regiztry.Controllers;

//namespace Regiztry.Tests
//{
//    //See NSpec.org for more... trying this out 
//    //Run the RunnerShim with TD.Net to execute all the NSpec tests with N
//    [TestFixture]
//    public class RunnerShim
//    {
//        [Test]
//        public void AllTests()
//        {
//            var finder = new ShimFinder(typeof(RunnerShim).Assembly.GetTypes());

//            var builder = new ContextBuilder(finder, new DefaultConventions());

//            var runner = new ContextRunner(builder);

//            runner.Run();

//            if (runner.Failures().Count() != 0)
//                Assert.Fail("Some NSpec test failed");
//        }
//    }

//    public class ShimFinder : ISpecFinder
//    {
//        private readonly Type[] types;

//        public ShimFinder(Type[] types)
//        {
//            this.types = types;
//        }

//        public IEnumerable<Type> SpecClasses()
//        {
//            return types;
//        }
//    }

//    class using_the_home_controller : nspec
//    {
//        readonly HomeController home = new HomeController();

//        void when_calling_actions_on_the_controller()
//        {
//            specify = () => home.Show().should_not_be_null();
//            specify = () => home.Contact().should_not_be_null();
//        }
//    }

//    class using_the_startups_controller : nspec
//    {
//        readonly StartupsController startups = new StartupsController();

//        void when_calling_actions_on_the_controller()
//        {
//            specify = () => startups.Show().should_not_be_null();
//            specify = () => startups.Create().should_not_be_null();
//        }
//    }
//}
