using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Areas.Admin.Models.Ventas;
using SIPI.Presentation.Website.Models.Shared;
using System;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Controllers
{
    public class VentasController : BaseAdminController
    {
        private readonly ControladorReportes _controladorReportes;

        public VentasController(ControladorReportes controladorReportes)
        {
            _controladorReportes = controladorReportes;
        }

        [HttpGet]
        public ActionResult Index(IndexFiltersModel filters)
        {
            return View(new IndexModel { Filters = filters });
        }

        [HttpGet]
        public ActionResult IndexTable(IndexFiltersModel filters, OffsetParams offset)
        {
            return Json(
                _controladorReportes
                    .ReporteVentasPorCategoria(filters.IdCategoria, filters.FechaDesde, filters.FechaHasta, offset.Offset, offset.Limit),
                JsonRequestBehavior.AllowGet);
        }
    }
}