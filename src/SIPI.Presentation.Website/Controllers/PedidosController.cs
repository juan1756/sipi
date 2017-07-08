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
    public class PedidosController : BaseController
    {
        private readonly ControladorPedidos _controladorPedidos;

        public PedidosController(ControladorPedidos controladorPedidos)
        {
            _controladorPedidos = controladorPedidos;
        }

        // TODO: Revisar roles
        [Authorize]
        public ActionResult MisPedidos()
        {
            return View();
        }

        [Authorize]
        public ActionResult MisPedidosTable(OffsetParams offset)
        {
            return Json(
                _controladorPedidos
                    .SeguirPedidosMiembro(UsuarioPrincipal.Actual.Usuario.Id, offset.Offset, offset.Limit), 
                JsonRequestBehavior.AllowGet);
        }
    }
}