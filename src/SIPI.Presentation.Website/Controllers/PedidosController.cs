using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Authentication;
using SIPI.Presentation.Website.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Controllers
{
    [Authorize(Roles = "Miembro")]
    public class PedidosController : BaseController
    {
        private readonly ControladorPedidos _controladorPedidos;

        public PedidosController(ControladorPedidos controladorPedidos)
        {
            _controladorPedidos = controladorPedidos;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexTable(OffsetParams offsetParams)
        {
            return Json(
                _controladorPedidos
                    .SeguirPedidosMiembro(Usuario.Id, offsetParams.Offset, offsetParams.Limit),
                JsonRequestBehavior.AllowGet);
        }
    }
}