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
            fechaDesde = fechaDesde.ConvertFromClientToUTC();
            fechaHasta = fechaHasta?.AddDays(1).ConvertFromClientToUTC();

            return _dbCtx.Pedidos
                .Where(fechaDesde.HasValue, x => x.Fecha >= fechaDesde.Value)
                .Where(fechaHasta.HasValue, x => x.Fecha <= fechaHasta.Value)
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