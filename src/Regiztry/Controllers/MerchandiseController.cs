using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{ 
    public class MerchandiseController : Controller
    {
        public ViewResult Show()
        {
            var merch = Regiztry.WorkOn(work => work.GetAll<Merchandise>().ToList());

            return View(merch);
        }

      public ViewResult Details(int id)
      {
          var merchandise = Regiztry.WorkOn(work => work.GetById<Merchandise>(id));

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
                Regiztry.WorkOn(work =>
                {
                    work.Insert(merchandise);
                    work.Commit();
                });
                return RedirectToAction("Show");  
            }

            return View(merchandise);
        }
        
        public ActionResult Edit(int id)
        {
            var merchandise = Regiztry.WorkOn(work => work.GetById<Merchandise>(id));
            return View(merchandise);
        }

        [HttpPost]
        public ActionResult Edit(Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                Regiztry.WorkOn(work =>
                {
                    work.Update(merchandise);
                    work.Commit();
                });
                return RedirectToAction("Show");
            }
            return View(merchandise);
        }

        public ActionResult Delete(int id)
        {
            var merchandise = Regiztry.WorkOn(work => work.GetById<Merchandise>(id));
            return View(merchandise);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Regiztry.WorkOn(work =>
            {
                work.DeleteById<Merchandise>(id);
                work.Commit();
            });
           return RedirectToAction("Show");
        }
    }
}