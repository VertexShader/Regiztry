using System.Data;
using System.Linq;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{ 
/*
    public class MerchSourceController : Controller
    {
        private RegiztryContext db = new RegiztryContext();

        public ViewResult Index()
        {
            return View(db.MerchSources.ToList());
        }

       public ViewResult Details(int id)
        {
            MerchSource merchsource = db.MerchSources.Find(id);
            return View(merchsource);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(MerchSource merchsource)
        {
            if (ModelState.IsValid)
            {
                db.MerchSources.Add(merchsource);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(merchsource);
        }
        
         public ActionResult Edit(int id)
        {
            MerchSource merchsource = db.MerchSources.Find(id);
            return View(merchsource);
        }

        [HttpPost]
        public ActionResult Edit(MerchSource merchsource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merchsource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(merchsource);
        }

        //
        // GET: /MerchSource/Delete/5
 
        public ActionResult Delete(int id)
        {
            MerchSource merchsource = db.MerchSources.Find(id);
            return View(merchsource);
        }

        //
        // POST: /MerchSource/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            MerchSource merchsource = db.MerchSources.Find(id);
            db.MerchSources.Remove(merchsource);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
*/
}