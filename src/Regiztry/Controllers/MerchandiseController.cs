using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Regiztry.Models;
using SisoDb;

namespace Regiztry.Controllers
{ 
    public class MerchandiseController : Controller
    {
        IUnitOfWork work = Regiztry.UnitOfWork();

        public ViewResult Index()
        {
            IEnumerable<Merchandise> merch = new List<Merchandise>();
            using (work) merch = work.GetAll<Merchandise>();

            return View(merch);
        }

      public ViewResult Details(int id)
        {
          Merchandise merchandise;
          using(work) merchandise = work.GetById<Merchandise>(id);

            return View(merchandise);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                using(work)
                {
                    work.Insert(merchandise);
                    work.Commit();
                }
                return RedirectToAction("Index");  
            }

            return View(merchandise);
        }
        
        public ActionResult Edit(int id)
        {
            Merchandise merchandise;
            using (work) merchandise = work.GetById<Merchandise>(id);
            return View(merchandise);
        }

        [HttpPost]
        public ActionResult Edit(Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                using(work)
                {
                    work.Update(merchandise);
                    work.Commit();
                }
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }

        public ActionResult Delete(int id)
        {
            Merchandise merchandise;
            using (work) merchandise = work.GetById<Merchandise>(id);
            return View(merchandise);
        }

       [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (work)
            {
                work.DeleteById<Merchandise>(id);
                work.Commit();
            }
           return RedirectToAction("Index");
        }
    }
}