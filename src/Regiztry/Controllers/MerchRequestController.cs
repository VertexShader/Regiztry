using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{ 
    public class MerchRequestController : Controller
    {
        private RegiztryContext db = new RegiztryContext();

       public ViewResult Index()
        {
            return View(db.MerchRequests.ToList());
        }

       public ViewResult Details(int id)
        {
            MerchRequest merchrequest = db.MerchRequests.Find(id);
            return View(merchrequest);
        }

       public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(MerchRequest merchrequest)
        {
            if (ModelState.IsValid)
            {
                db.MerchRequests.Add(merchrequest);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(merchrequest);
        }
        
       public ActionResult Edit(int id)
        {
            MerchRequest merchrequest = db.MerchRequests.Find(id);
            return View(merchrequest);
        }

       [HttpPost]
        public ActionResult Edit(MerchRequest merchrequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(merchrequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(merchrequest);
        }

        public ActionResult Delete(int id)
        {
            MerchRequest merchrequest = db.MerchRequests.Find(id);
            return View(merchrequest);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            MerchRequest merchrequest = db.MerchRequests.Find(id);
            db.MerchRequests.Remove(merchrequest);
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