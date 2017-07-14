using System.Web.Mvc;

namespace SIPI.Presentation.Website.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}