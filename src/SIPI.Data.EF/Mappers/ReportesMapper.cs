using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Where(fechaDesde.HasValue, x => x.Fecha >= fechaDesde)
                .Where(fechaHasta.HasValue, x => x.Fecha <= fechaHasta)
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
                .ToPagedCollection(desde,cantidad);
        }
    }
}
