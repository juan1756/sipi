using System;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Contenido")]
    public class CategoriasController : BaseAdminController
    {
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}