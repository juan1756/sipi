using System.Web.Mvc;

namespace SIPI.Presentation.Website.Controllers
{
    public class ErrorController : BaseController
    {
        [ActionName("404")]
        public ActionResult NotFound()
        {
            return View();
        }

        [ActionName("500")]
        public ActionResult Conflict()
        {
            return View();
        }

        [ActionName("501")]
        public ActionResult NotImplemented()
        {
            return View();
        }
    }
}