using System;
using System.Web.Mvc;

namespace Regiztry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Show()
        {
            return View();
        }

        public object Contact()
        {
            return View();
        }
    }
}
