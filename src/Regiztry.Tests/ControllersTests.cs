using System;
using System.Collections.Generic;
using System.Linq;
using NSpec;
using NSpec.Domain;
using NUnit.Framework;
using Regiztry.Controllers;
using Regiztry.Models;
using SisoDb;

namespace Regiztry.Tests {
    //See NSpec.org for more... trying this out 
    //Run the RunnerShim with TD.Net to execute all the NSpec tests with N
    [TestFixture]
    public class RunnerShim {
        [Test]
        public void AllTests() {
            var finder = new ShimFinder(typeof(RunnerShim).Assembly.GetTypes());

            var builder = new ContextBuilder(finder, new DefaultConventions());

            var runner = new ContextRunner(builder);

            runner.Run();
            var results = runner.Failures();
            if (results.Count() != 0) {
                foreach (var result in results)
                    Assert.Fail(String.Format("{0} failed because of {1}", result.Spec, result.Exception));
            } else {

            } Assert.Pass("All " + runner.Examples().Count() + " passed");
                
        }
    }

    public class ShimFinder : ISpecFinder {
        private readonly Type[] types;

        public ShimFinder(Type[] types) {
            this.types = types;
        }

        public IEnumerable<Type> SpecClasses() {
            return types;
        }
    }

    public class using_the_home_controller : nspec {
        readonly HomeController home = new HomeController();

        void when_calling_actions_on_the_controller() {
            specify = () => home.Show().should_not_be_null();
            specify = () => home.Contact().should_not_be_null();
            specify = () => home.About().should_not_be_null();
        }
    }

    public class using_the_startups_controller : nspec {
        readonly StartupsController startups = new StartupsController();
        readonly QueryDelegate<IList<Startup>> mockQueryDelegate = mockDBCall;

        public static IList<Startup> mockDBCall(Func<IQueryEngine, IList<Startup>> query) {
            return new List<Startup>{ new Startup {Name="test" } };
        }
        void when_calling_actions_on_the_controller() {
            startups.QueryAll = mockQueryDelegate;
            specify = () => startups.Show().should_not_be_null();
            specify = () => startups.Create().should_not_be_null();
        }
    }

    public class using_the_merchandise_controller : nspec
    {
        readonly MerchandiseController merchandise = new MerchandiseController();

        void when_calling_actions_on_the_merchandise_controller()
        {
            specify = () => merchandise.Show().should_not_be_null();
            specify = () => merchandise.Create();
        }
    }

}
