using System.Web.Mvc;

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

        public ViewResult About()
        {
            return View();
        }
    }
}
