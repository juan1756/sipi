using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static SIPI.Core.Entidades.Pedido;

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
            return _dbCtx.Pedidos
                .Where(!string.IsNullOrEmpty(nombreApellidoMiembro), x => (x.Miembro.Nombre + " " + x.Miembro.Apellido).Contains(nombreApellidoMiembro))
                .Where(fechaDesde.HasValue, x => DbFunctions.TruncateTime(x.Fecha) >= DbFunctions.TruncateTime(fechaDesde.Value))
                .Where(fechaHasta.HasValue, x => DbFunctions.TruncateTime(x.Fecha) <= DbFunctions.TruncateTime(fechaHasta.Value))
                .OrderByDescending(x => x.Fecha)
                .ToPagedCollection(desde, cantidad);
        }
    }
}