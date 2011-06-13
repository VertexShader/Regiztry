using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Settings()
        {
            var model = new Setting();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
