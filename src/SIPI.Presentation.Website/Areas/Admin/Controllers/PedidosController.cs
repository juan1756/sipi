using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Areas.Admin.Models.Pedidos;
using SIPI.Presentation.Website.Models.Shared;
using System;
using System.Web.Mvc;
using static SIPI.Core.Entidades.Pedido;

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
            if (filtros.Desde.HasValue && filtros.Hasta.HasValue
                && filtros.Desde > filtros.Hasta)
            {
                TempData.Add("Error-Notifications-Filtros", "La Fecha desde debe ser menor o igual a la Fecha hasta");
                return RedirectToAction("index", "pedidos", new { area = "admin" });
            }

            return View(filtros);
        }

        public ActionResult IndexTable(IndexFiltrosModel filtros, OffsetParams offsetParams)
        {
            return Json(
                _controladorPedidos.SeguirPedidosOperador(Usuario.Email, filtros.Miembro, filtros.Desde, filtros.Hasta, offsetParams.Offset, offsetParams.Limit),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(IndexFiltrosModel filtros, int numero)
        {
            try
            {
                _controladorPedidos.CambiarEstadoPedido(numero, Usuario.Email);
            }
            catch (UsuarioNoTienePermisosParaModificarEstadoException ex)
            {
                if (!TempData.ContainsKey("Error-Notifications-CambiarEstado"))
                {
                    TempData.Add("Error-Notifications-CambiarEstado", ex.Message);
                }
            }
            return View(filtros);
        }
    }
}