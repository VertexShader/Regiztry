using System.Linq;
using System.Web.Mvc;
using Regiztry.Models;
using System.Collections.Generic;

namespace Regiztry.Controllers
{
    public class StartupsController : RegiztryBaseController {

        public QueryDelegate<IList<Startup>> QueryAll;
        public GenericWorkOnDelegate<Startup> WorkOnStartup;

        public StartupsController() {
            QueryAll = Regiztry.GetQueryDelegate<IList<Startup>>();
            WorkOnStartup = Regiztry.GetGenericWorkOnDelegate<Startup>();
        }
                                                                    
        public ActionResult Show() {
            var startups = QueryAll(query => query.GetAll<Startup>().ToList());
            return View(startups);
        }

        public ActionResult Create() {
            return View(new Startup());
        }

        [HttpPost]
        public ActionResult Create(Startup startup) {
            startup.Active = true;

            try {
                workOnDelegate(work => {
                    work.Insert(startup);
                    work.Commit();
                });
                return RedirectToAction("Show");
            } catch {
                return View();
            }
        }

    }
}