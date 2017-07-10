using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Areas.Admin.Models.Pedidos;
using SIPI.Presentation.Website.Models.Shared;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    public class PedidosController : BaseAdminController
    {
        private readonly ControladorPedidos _controladorPedidos;

        public PedidosController(ControladorPedidos controladorPedidos)
        {
            _controladorPedidos = controladorPedidos;
        }

        public ActionResult Index(IndexFiltros filtros)
        {
            return View(filtros);
        }

        public ActionResult IndexTable(IndexFiltros filtros, OffsetParams offsetParams)
        {
            return Json(
                _controladorPedidos.SeguirPedidosOperador(filtros.Miembro, filtros.Desde, filtros.Hasta, offsetParams.Offset, offsetParams.Limit),
                JsonRequestBehavior.AllowGet);
        }
    }
}