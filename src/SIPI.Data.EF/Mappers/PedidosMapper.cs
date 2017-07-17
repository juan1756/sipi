using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
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

        public IPagedCollection<Pedido> ObtenerPedidos(int id, int desde, int cantidad)
        {
            return _dbCtx.Pedidos
                .Where(x => x.Miembro.Id == id)
                .OrderByDescending(x => x.Fecha)
                .ToPagedCollection(desde, cantidad);
        }

        public IPagedCollection<Pedido> ObtenerPedidos(string[] roles, string nombreApellidoMiembro, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            List<int> estados = new List<int>();
            if (roles.Contains("Packaging"))
            {
                estados.Add((int)Estados.Nuevo);
            }
            if (roles.Contains("Vendedor"))
            {
                estados.Add((int)Estados.Listo);
            }

            return _dbCtx.Pedidos
                .Where(!string.IsNullOrEmpty(nombreApellidoMiembro), x => (x.Miembro.Nombre + " " + x.Miembro.Apellido).Contains(nombreApellidoMiembro))
                .Where(fechaDesde.HasValue, x => fechaDesde <= x.Fecha)
                .Where(fechaHasta.HasValue, x => x.Fecha <= fechaHasta)
                .Where(x => estados.Contains(x.Estado))
                .OrderByDescending(x => x.Fecha)
                .ToPagedCollection(desde, cantidad);
        }
    }
}