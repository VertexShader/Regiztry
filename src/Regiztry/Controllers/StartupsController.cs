using System.Linq;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{
    public class StartupsController : Controller
    {
        public ActionResult Show()
        {
            var startups = Regiztry.WorkOn(unitOfWork => unitOfWork.GetAll<Startup>().ToList());
            return View(startups);
        }

        public ActionResult Details(int id)
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return View(new Startup());
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var startup = new Startup {Name = collection["Name"]};
                Regiztry.WorkOn(work =>
                    {
                        work.Insert(startup);
                        work.Commit();
                    });
                return RedirectToAction("Show");
            }
            catch
            {
                return View();
            }
        }
       
    }
}
