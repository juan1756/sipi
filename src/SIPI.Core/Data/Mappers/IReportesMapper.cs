using SIPI.Core.Data.DTO;
using SIPI.Core.Vistas;
using System;

namespace SIPI.Core.Data.Mappers
{
    public interface IReportesMapper
    {
        IPagedCollection<ReporteVentasPorCategoriaView> VentasPorCategoria
            (int? idCategoria, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad);
    }
}