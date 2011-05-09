using System;
using System.Web.Mvc;

namespace Regiztry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public object Contact()
        {
            return View();
        }
    }
}
