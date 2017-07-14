using SIPI.Core.Data.DTO;
using SIPI.Core.Entidades;
using System;

namespace SIPI.Core.Data.Mappers
{
    public interface IPedidosMapper
    {
        IPagedCollection<Pedido> ObtenerPedidos(int id, int desde, int cantidad);

        IPagedCollection<Pedido> ObtenerPedidos(string[] roles, string nombreApellidoMiembro, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad);

        Pedido ObtenerPedido(int numero);
    }
}