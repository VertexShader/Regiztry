using System.Collections.Generic;
using System.Web.Mvc;
using Web.Codez;
using Web.Models;

namespace Web.Controllers
{
    public class StartupController : Controller
    {
        public ViewResult Index()
        {
            StartupRepository startupRepo = new StartupRepository();
            var startups = startupRepo.GetAllStartups();
                //new List<Startup> { new Startup() { Address = "Chicago Place", Name = "MercuryApp", State = "IL" } };

            return View(startups);
        }


        public ActionResult Details(int id)
        {
            var startup = new Startup(){Address = "Chicago Place", Name="MercuryApp", State = "IL", Needs=new List<NeededStuff> ()};

            return View(startup);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
