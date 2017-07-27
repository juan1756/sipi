using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Areas.Admin.Models.Ventas;
using SIPI.Presentation.Website.Models.Shared;
using System;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Vendedor")]
    public class VentasController : BaseAdminController
    {
        private readonly ControladorReportes _controladorReportes;
        private readonly ControladorCategorias _controladorCategorias;

        public VentasController(
            ControladorReportes controladorReportes,
            ControladorCategorias controladorCategorias)
        {
            _controladorReportes = controladorReportes;
            _controladorCategorias = controladorCategorias;
        }

        [HttpGet]
        public ActionResult Index(IndexFiltrosModel filtros)
        {
            if (filtros.FechaDesde.HasValue && filtros.FechaHasta.HasValue
                && filtros.FechaDesde > filtros.FechaHasta)
            {
                TempData.Add("Error-Notifications-Filtros", "La Fecha desde debe ser menor o igual a la Fecha hasta");
                return RedirectToAction("index", "ventas", new { area = "admin", IdCategoria = filtros.IdCategoria });
            }

            return View(
                new IndexModel(
                    _controladorCategorias.ObtenerCategorias(), 
                    filtros));
        }

        [HttpGet]
        public ActionResult IndexTable(IndexFiltrosModel filtros, OffsetParams offsetParams)
        {
            return Json(
                _controladorReportes
                    .ReporteVentasPorCategoria(filtros.IdCategoria, filtros.FechaDesde, filtros.FechaHasta, offsetParams.Offset, offsetParams.Limit),
                JsonRequestBehavior.AllowGet);
        }
    }
}