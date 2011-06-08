using System.Web.Mvc;
using Regiztry.Models;

namespace Regiztry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Show()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

        public ViewResult Send(ContactMessage contactMessage)
        {



            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}
