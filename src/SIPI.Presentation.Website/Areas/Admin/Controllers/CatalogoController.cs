using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Contenido")]
    public class CatalogoController : BaseAdminController
    {
        public ActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}