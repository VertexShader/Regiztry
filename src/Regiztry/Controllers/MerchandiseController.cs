using System.Data;
using System.Linq;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{ 
    public class MerchandiseController : Controller
    {
        private RegiztryContext db = new RegiztryContext();

        public ViewResult Index()
        {
            return View(db.MerchandiseItems.ToList());
        }

      public ViewResult Details(int id)
        {
            Merchandise merchandise = db.MerchandiseItems.Find(id);
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
                db.MerchandiseItems.Add(merchandise);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(merchandise);
        }
        
        public ActionResult Edit(int id)
        {
            Merchandise merchandise = db.MerchandiseItems.Find(id);
            return View(merchandise);
        }

        [HttpPost]
        public ActionResult Edit(Merchandise merchandise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merchandise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(merchandise);
        }

        public ActionResult Delete(int id)
        {
            Merchandise merchandise = db.MerchandiseItems.Find(id);
            return View(merchandise);
        }

       [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Merchandise merchandise = db.MerchandiseItems.Find(id);
            db.MerchandiseItems.Remove(merchandise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}