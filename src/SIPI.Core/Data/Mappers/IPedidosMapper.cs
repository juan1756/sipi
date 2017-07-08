using SIPI.Core.Data.DTO;
using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Data.Mappers
{
    public interface IPedidosMapper
    {
        IPagedCollection<Pedido> ObtenerPedidos(int id, int desde, int cantidad);
    }
}
