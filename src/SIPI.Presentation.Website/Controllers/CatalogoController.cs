using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Authentication;
using SIPI.Presentation.Website.Models.Catalogo;
using SIPI.Presentation.Website.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Index(IndexFiltrosModel filtros)
        {
            return View(
                new IndexModel(
                    _controladorCategorias.ObtenerCategorias(),
                    _controladorTipos.ObtenerTipos(),
                    filtros));
        }

        public ActionResult IndexTable(IndexFiltrosModel filtros, OffsetParams offsetParams)
        {
            _controladorMedios.ObtenerCatalogo(filtros.CategoriaId, filtros.Tema, filtros.FechaDesde, 
                filtros.FechaHasta, filtros.TipoId, offsetParams.Offset, offsetParams.Offset);

            return null;
        }
    }
}