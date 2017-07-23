using SIPI.Core.Controladores;
using SIPI.Presentation.Website.Models.Pedidos;
using SIPI.Presentation.Website.Models.Shared;
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
        private readonly ControladorCuentas _controladorCuentas;
        private readonly ControladorProvincias _controladorProvincias;
        private readonly ControladorLocalidades _controladorLocalidades;

        public PedidosController(
            ControladorPedidos controladorPedidos,
            ControladorMediosAudiovisuales controladorMedios,
            ControladorCategorias controladorCategorias,
            ControladorTipos controladorTipos,
            ControladorCuentas controladorCuentas,
            ControladorProvincias controladorProvincias,
            ControladorLocalidades controladorLocalidades)
        {
            _controladorPedidos = controladorPedidos;
            _controladorMedios = controladorMedios;
            _controladorCategorias = controladorCategorias;
            _controladorTipos = controladorTipos;
            _controladorCuentas = controladorCuentas;
            _controladorProvincias = controladorProvincias;
            _controladorLocalidades = controladorLocalidades;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexTable(OffsetParams offsetParams)
        {
            return Json(
                _controladorPedidos
                    .SeguirPedidosMiembro(Usuario.Email, offsetParams.Offset, offsetParams.Limit),
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
            if (!ModelState.IsValid)
                return RedirectToAction("crear", "pedidos", new { area = "" });

            if (crear.Medios == null || !crear.Medios.Any())
            {
                var offsetParams = new OffsetParams() { Offset = 0, Limit = 8 };
                TempData["Error-Notifications-Confirmar"] = "El pedido debe contener al menos un medio audiovisual seleccionado";
                return View(
                    new Models.Catalogo.IndexModel(
                        categorias: _controladorCategorias.ObtenerCategorias(),
                        tipos: _controladorTipos.ObtenerTipos(),
                        filtros: filtros,
                        medios: _controladorMedios.ObtenerCatalogo(filtros.CategoriaId, filtros.Tema, filtros.FechaDesde, filtros.FechaHasta, filtros.TipoId, offsetParams.Offset, offsetParams.Limit),
                        offsetParams: offsetParams));
            }

            var mediosViews = _controladorMedios
                .ObtenerCatalogo(filtros.CategoriaId, filtros.Tema, filtros.FechaDesde, filtros.FechaHasta, filtros.TipoId, 0, int.MaxValue)
                .Rows
                .ToList();

            if (!crear.SelectAll)
            {
                mediosViews = mediosViews
                    .Where(x => crear.Medios.Contains(x.Id))
                    .ToList();
            }

            return View(
                "Confirmar",
                new ConfirmarModel(
                    provincias: _controladorProvincias.ObtenerProvincias(),
                    localidades: _controladorLocalidades.ObtenerLocalidades(),
                    medios: mediosViews,
                    miembro: _controladorCuentas.BuscarMiembro(Usuario.Identity.Name)));
        }

        [HttpPost]
        public ActionResult Confirmar(
            ConfirmarPedidoModel confirmarPedidoModel,
            MiembroDireccionModel miembroDireccionModel)
        {
            if (!ModelState.IsValid)
                return View(
                    new ConfirmarModel(
                        provincias: _controladorProvincias.ObtenerProvincias(),
                        localidades: _controladorLocalidades.ObtenerLocalidades(),
                        medios: _controladorMedios.ObtenerMedios(confirmarPedidoModel.Medios),
                        miembro: _controladorCuentas.BuscarMiembro(Usuario.Identity.Name)));

            _controladorCuentas
                .ConfirmarDireccion(
                    Usuario.Email,
                    miembroDireccionModel.ProvinciaId, miembroDireccionModel.LocalidadId, miembroDireccionModel.Calle, miembroDireccionModel.Altura, miembroDireccionModel.Piso
                );

            _controladorPedidos
                .AgregarPedido(
                    Usuario.Email,
                    confirmarPedidoModel.Medios, confirmarPedidoModel.CantidadCopias
                );

            return RedirectToAction("index", "pedidos", new { area = "" });
        }
    }
}