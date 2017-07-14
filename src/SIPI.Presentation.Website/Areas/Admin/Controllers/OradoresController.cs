using System;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Contenido")]
    public class OradoresController : BaseAdminController
    {
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}