using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Controladores
{
    public class ControladorReportes
    {
        private readonly IReportesMapper _reportes;

        public ControladorReportes(IReportesMapper reportes)
        {
            _reportes = reportes;
        }

        public IPagedCollection<ReporteVentasPorCategoriaView> ReporteVentasPorCategoria(
            int? idCategoria, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            return _reportes
                .VentasPorCategoria(idCategoria, fechaDesde, fechaHasta, desde, cantidad);
        }
    }
}
