using SIPI.Core.Controladores;
using SIPI.Core.Data.DTO;
using SIPI.Core.Vistas;
using SIPI.Presentation.Website.Models.Pedidos;
using SIPI.Presentation.Website.Models.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Controllers
{
    [Authorize(Roles = "Miembro")]
    public class PedidosController : BaseController
    {
        private readonly ControladorPedidos _controladorPedidos;
        private readonly ControladorMediosAudiovisuales _controladorMedios;
        private readonly ControladorCategorias _controladorCategorias;
        private readonly ControladorTipos _controladorTipos;

        public PedidosController(
            ControladorPedidos controladorPedidos,
            ControladorMediosAudiovisuales controladorMedios,
            ControladorCategorias controladorCategorias,
            ControladorTipos controladorTipos)
        {
            _controladorPedidos = controladorPedidos;
            _controladorMedios = controladorMedios;
            _controladorCategorias = controladorCategorias;
            _controladorTipos = controladorTipos;
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

        public ActionResult Crear(Models.Catalogo.IndexFiltrosModel filtros, OffsetParams offsetParams)
        {
            if (offsetParams.Limit == 0)
                offsetParams.Limit = 8;

            return View(
                    new Models.Catalogo.IndexModel(
                        categorias: _controladorCategorias.ObtenerCategorias(),
                        tipos: _controladorTipos.ObtenerTipos(),
                        filtros: filtros,
                        medios: _controladorMedios.ObtenerCatalogo(filtros.CategoriaId, filtros.Tema, filtros.FechaDesde, filtros.FechaHasta, filtros.TipoId, offsetParams.Offset, offsetParams.Limit),
                        offsetParams: offsetParams));
        }

        [HttpPost]
        public ActionResult Crear(Models.Catalogo.IndexFiltrosModel filtros, CrearModel crear)
        {
            var mediosViews = _controladorMedios
                .ObtenerCatalogo(filtros.CategoriaId, filtros.Tema, filtros.FechaDesde, filtros.FechaHasta, filtros.TipoId, 0, int.MaxValue)
                .ToList();

            if (!crear.SelectAll)
            {
                mediosViews = mediosViews
                    .Where(x => crear.Medios.Contains(x.Id))
                    .ToList();
            }

            return View("Confirmar", mediosViews);
            //return Json(mediosViews);
        }
    }
}