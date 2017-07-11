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

        public IPagedCollection<ReporteVentasPorCategoriaView> VentasPorCategoria
            (int? idCategoria, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            //return _dbCtx.Pedidos
            //          .Where(fechaDesde.HasValue, x => x.Fecha >= fechaDesde)
            //          .Where(fechaHasta.HasValue, x => x.Fecha <= fechaHasta)
            //          .GroupBy(p => p.Insumos.SelectMany(i => i.Medios)
            //                    .Where(m => m.Categoria.Id == idCategoria.Value))
            //          .Select(r => new ReporteVentasPorCategoriaView()
            //          {
            //              NombreCategoria = r.FirstOrDefault().Insumos.SelectMany(i => i.Medios)
            //                    .Where(m => m.Categoria.Id == idCategoria.Value).FirstOrDefault().Categoria.Nombre,
            //              Cantidad = r.Count()
            //          }
            //          )
            //          .OrderByDescending(o => o.Cantidad)
            //          .ToPagedCollection(desde, cantidad);

            var res = _dbCtx.MediosAudiovisuales.Select(x => new ReporteVentasPorCategoriaView()
            {
                NombreCategoria = x.Categoria.Nombre,
                Cantidad = _dbCtx.Pedidos
                            .Where(p => !fechaDesde.HasValue || p.Fecha >= fechaDesde.Value)
                            .Where(p => !fechaHasta.HasValue || p.Fecha <= fechaHasta.Value)
                            .Where(p => !idCategoria.HasValue || p.Insumos.Any(i => i.Medios.Any(m => m.Categoria.Id == idCategoria.Value))).Count()
                            //.Where(fechaDesde.HasValue, p => p.Fecha >= fechaDesde.Value)
                            //.Where(fechaHasta.HasValue, p => p.Fecha <= fechaHasta.Value).Count()
                            //.Where(idCategoria.HasValue, p => p.Insumos.Any(i => i.Medios.Any(m => m.Categoria.Id == x.Categoria.Id))).Count()
            })
            .Distinct()
            .OrderByDescending(o => o.Cantidad)
            .ToPagedCollection(desde, cantidad);

            return res;
        }
    }
}
