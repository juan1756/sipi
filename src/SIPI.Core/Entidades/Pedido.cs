using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SIPI.Core.Entidades
{
    public class Pedido
    {
        public enum Estados
        {
            Nuevo,
            Listo,
            Entregado
        }

        private Pedido()
        {
            Insumos = new Collection<Insumo>();
        }

        public Pedido(int cantidadPedido, Miembro miembro)
        {
            CantidadPedido = cantidadPedido;
            Estado = (int)Estados.Nuevo;
            Fecha = DateTime.Now;
            Miembro = miembro;
            Insumos = new Collection<Insumo>();
        }

        public int Numero { get; private set; }

        public int CantidadPedido { get; private set; }

        public int Estado { get; private set; }

        public DateTime Fecha { get; private set; }

        public virtual Miembro Miembro { get; private set; }

        public decimal PrecioTotal { get; private set; }

        public virtual ICollection<Insumo> Insumos { get; private set; }

        public DateTime? FechaEntregado { get; private set; }

        public PedidoOperadorView GetOperadorView()
        {
            // TODO: El Tema esta perdido, revisar docs
            return new PedidoOperadorView(
                Numero, 
                null, 
                $"{Miembro.Nombre} {Miembro.Apellido}", 
                CantidadPedido, 
                Fecha, 
                (Estados)Estado, 
                ((Estados)Estado) == Estados.Nuevo 
                    ? Estados.Listo 
                    : Estados.Entregado);
        }

        public PedidoMiembroView GetMiembroView()
        {
            // TODO: El Tema esta perdido, revisar docs
            return new PedidoMiembroView(
                Insumos.SelectMany(x => x.Medios.Select(y => y.Tema)).Distinct().ToList(), 
                CantidadPedido, 
                Fecha, 
                (Estados)Estado, 
                FechaEntregado);
        }
    }
}