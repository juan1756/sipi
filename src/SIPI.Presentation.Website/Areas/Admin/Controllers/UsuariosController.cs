using System;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Contenido, Vendedor, Packaging")]
    public class UsuariosController : BaseAdminController
    {
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}