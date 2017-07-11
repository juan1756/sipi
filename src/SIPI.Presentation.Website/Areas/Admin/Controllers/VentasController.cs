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
        public ActionResult Index(IndexFiltros filtros)
        {
            return View(filtros);
        }

        [HttpGet]
        public ActionResult IndexTable(IndexFiltros filtros, OffsetParams offsetParams)
        {
            return Json(
                _controladorReportes
                    .ReporteVentasPorCategoria(filtros.IdCategoria, filtros.Desde, filtros.Hasta, offsetParams.Offset, offsetParams.Limit),
                JsonRequestBehavior.AllowGet);
        }
    }
}