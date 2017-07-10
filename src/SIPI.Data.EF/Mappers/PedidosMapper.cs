using SIPI.Core.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIPI.Core.Data.DTO;
using SIPI.Core.Entidades;

namespace SIPI.Data.EF.Mappers
{
    public class PedidosMapper : IPedidosMapper
    {
        private readonly DataContext _dbCtx;

        public PedidosMapper(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public IPagedCollection<Pedido> ObtenerPedidos(int id, int desde, int cantidad)
        {
            return _dbCtx.Pedidos
                .Where(x => x.Miembro.Id == id)
                .OrderByDescending(x => x.Fecha)
                .ToPagedCollection(desde, cantidad);
        }

        public IPagedCollection<Pedido> ObtenerPedidos(string nombreApellidoMiembro, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            return _dbCtx.Pedidos
                .Where(!string.IsNullOrEmpty(nombreApellidoMiembro), x => (x.Miembro.Nombre + " " + x.Miembro.Apellido).Contains(nombreApellidoMiembro))
                .Where(fechaDesde.HasValue, x => fechaDesde <= x.Fecha)
                .Where(fechaHasta.HasValue, x => x.Fecha <= fechaHasta)
                .OrderByDescending(x => x.Fecha)
                .ToPagedCollection(desde, cantidad);
        }
    }
}
