using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Areas.Admin.Models.Pedidos;
using SIPI.Presentation.Website.Models.Shared;
using System;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Vendedor, Packaging")]
    public class PedidosController : BaseAdminController
    {
        private readonly ControladorPedidos _controladorPedidos;

        public PedidosController(ControladorPedidos controladorPedidos)
        {
            _controladorPedidos = controladorPedidos;
        }

        public ActionResult Index(IndexFiltrosModel filtros)
        {
            return View(filtros);
        }

        public ActionResult IndexTable(IndexFiltrosModel filtros, OffsetParams offsetParams)
        {
            return Json(
                _controladorPedidos.SeguirPedidosOperador(Usuario.Roles, filtros.Miembro, filtros.Desde, filtros.Hasta, offsetParams.Offset, offsetParams.Limit),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(IndexFiltrosModel filtros, int numero)
        {
            try
            {
                _controladorPedidos.CambiarEstadoPedido(numero, Usuario.Roles);
            }
            catch (Exception ex)
            {
                TempData.Add("Error-Notifications-CambiarEstado", ex.Message);
            }
            return View(filtros);
        }
    }
}