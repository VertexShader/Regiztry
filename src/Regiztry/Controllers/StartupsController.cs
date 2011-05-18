﻿using System.Linq;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{
    public class StartupsController : Controller
    {
        public ActionResult Show()
        {
            var startups = Regiztry.QueryWith(query => query.GetAll<Startup>().ToList());
            return View(startups);
        }

        public ActionResult Create()
        {
            return View(new Startup());
        }

        [HttpPost]
        public ActionResult Create(Startup startup)
        {
            startup.Active = true;

            try
            {
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
