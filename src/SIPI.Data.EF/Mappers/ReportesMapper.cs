using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System;
using System.Data.Entity;
using System.Linq;

namespace SIPI.Data.EF.Mappers
{
    public class ReportesMapper : IReportesMapper
    {
        private readonly DataContext _dbCtx;

        public ReportesMapper(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public IPagedCollection<ReporteVentasPorCategoriaView> VentasPorCategoria(int? idCategoria, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            return _dbCtx.Pedidos
                .Where(fechaDesde.HasValue, x => DbFunctions.TruncateTime(x.Fecha) >= DbFunctions.TruncateTime(fechaDesde.Value))
                .Where(fechaHasta.HasValue, x => DbFunctions.TruncateTime(x.Fecha) <= DbFunctions.TruncateTime(fechaHasta.Value))
                .SelectMany(x => x.Insumos)
                .SelectMany(x => x.Medios)
                .Where(idCategoria.HasValue, x => x.Categoria.Id == idCategoria)
                .GroupBy(x => x.Categoria.Id)
                .Select(x => new ReporteVentasPorCategoriaView()
                {
                    NombreCategoria = x.FirstOrDefault().Categoria.Nombre,
                    Cantidad = x.Count()
                })
                .OrderByDescending(x => x.Cantidad)
                .ToPagedCollection(desde, cantidad);
        }
    }
}