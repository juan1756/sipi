using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Models.Catalogo;
using SIPI.Presentation.Website.Models.Shared;
using System.Linq;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Controllers
{
    public class CatalogoController : BaseController
    {
        private readonly ControladorMediosAudiovisuales _controladorMedios;
        private readonly ControladorCategorias _controladorCategorias;
        private readonly ControladorTipos _controladorTipos;

        public CatalogoController(
            ControladorMediosAudiovisuales controladorMedios,
            ControladorCategorias controladorCategorias,
            ControladorTipos controladorTipos)
        {
            _controladorMedios = controladorMedios;
            _controladorCategorias = controladorCategorias;
            _controladorTipos = controladorTipos;
        }

        public ActionResult Index(IndexFiltrosModel filtros, OffsetParams offsetParams, string createOrder)
        {
            if (Usuario != null && !Usuario.IsInRole("Miembro"))
                return new HttpUnauthorizedResult();

            if (filtros.FechaDesde.HasValue && filtros.FechaHasta.HasValue
                && filtros.FechaHasta < filtros.FechaDesde)
            {
                TempData.Add("Error-Notifications-Filtros", "La Fecha desde debe ser menor o igual a la Fecha hasta");
                return RedirectToAction("index", "catalogo", new { area = "" });
            }

            if (offsetParams.Limit == 0)
                offsetParams.Limit = 8;

            if (createOrder == null)
            {
                return View(
                    new IndexModel(
                        categorias: _controladorCategorias.ObtenerCategorias(),
                        tipos: _controladorTipos.ObtenerTipos(),
                        filtros: filtros,
                        medios: _controladorMedios.ObtenerCatalogo(filtros.CategoriaId, filtros.Tema, filtros.FechaDesde, filtros.FechaHasta, filtros.TipoId, offsetParams.Offset, offsetParams.Limit),
                        offsetParams: offsetParams));
            }
            else
            {
                return RedirectToAction("crear", "pedidos", new
                {
                    area = "",
                    CategoriaId = filtros.CategoriaId,
                    Tema = filtros.Tema,
                    FechaDesde = filtros.FechaDesde?.ToShortDateString(),
                    FechaHasta = filtros.FechaHasta?.ToShortDateString(),
                    TipoId = filtros.TipoId
                });
            }
        }
    }
}