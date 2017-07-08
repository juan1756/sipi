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
    }
}
