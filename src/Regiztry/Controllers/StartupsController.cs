using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{
    public class StartupsController : Controller
    {
        public ActionResult Show()
        {
            List<Startup> startups;
            using(var work = Regiztry.UnitOfWork())
                startups = work.GetAll<Startup>().ToList();

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
                using(var work = Regiztry.UnitOfWork())
                {
                    work.Insert(startup);
                    work.Commit();
                }
                return RedirectToAction("Show");
            }
            catch
            {
                return View();
            }
        }
       
    }
}
