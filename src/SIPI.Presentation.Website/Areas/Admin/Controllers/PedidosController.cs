using SIPI.Presentation.Website.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    public class PedidosController : BaseAdminController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}