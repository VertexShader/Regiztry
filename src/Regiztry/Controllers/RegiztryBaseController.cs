using System.Web.Mvc;
using Regiztry.Models;
using System.Collections.Generic;

namespace Regiztry.Controllers {
    public class RegiztryBaseController : Controller {

        public WorkOnDelegate workOnDelegate;

        protected RegiztryBaseController()
            : base() {

            workOnDelegate = Regiztry.GetWorkOnDelegate();
        }
    }
}
