using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System;
using System.Linq;

namespace SIPI.Data.EF.Mappers
{
    public class PedidosMapper : IPedidosMapper
    {
        private readonly DataContext _dbCtx;

        public PedidosMapper(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public void Agregar(Pedido pedido)
        {
            _dbCtx.Pedidos.Add(pedido);
        }

        public Pedido ObtenerPedido(int numero)
        {
            return _dbCtx.Pedidos.Find(numero);
        }

        public IPagedCollection<Pedido> ObtenerPedidos(string email, int desde, int cantidad)
        {
            return _dbCtx.Pedidos
                .Where(x => x.Miembro.Email == email)
                .OrderByDescending(x => x.Fecha)
                .ToPagedCollection(desde, cantidad);
        }

        public IPagedCollection<Pedido> ObtenerPedidos(string[] roles, string nombreApellidoMiembro, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            fechaDesde = fechaDesde.ConvertFromClientToUTC();
            fechaHasta = fechaHasta?.AddDays(1).ConvertFromClientToUTC();

            return _dbCtx.Pedidos
                .Where(!string.IsNullOrEmpty(nombreApellidoMiembro), x => (x.Miembro.Nombre + " " + x.Miembro.Apellido).Contains(nombreApellidoMiembro))
                .Where(fechaDesde.HasValue, x => x.Fecha >= fechaDesde.Value)
                .Where(fechaHasta.HasValue, x => x.Fecha <= fechaHasta.Value)
                .OrderByDescending(x => x.Fecha)
                .ToPagedCollection(desde, cantidad);
        }
    }
}