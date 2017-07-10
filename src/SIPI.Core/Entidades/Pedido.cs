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

        protected Pedido()
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

        // TODO: Cambiar DS
        public PedidoOperadorView GetOperadorView(string[] roles)
        {
            return new PedidoOperadorView(
                Numero,
                Insumos.SelectMany(x => x.Medios.Select(y => y.Tema)).Distinct().ToList(), 
                $"{Miembro.Nombre} {Miembro.Apellido}", 
                CantidadPedido, 
                Fecha,
                (Estados)Estado,
                ObtenerEstadoSiguiente(),
                PuedeCambiarEstado(roles));
        }

        // TODO: Cambiar DC
        // TODO: Cambiar DS
        public void CambiarEstado(string[] roles)
        {
            if (!PuedeCambiarEstado(roles))
                throw new Exception("El usuario no tiene permisos para cambiar el estado");

            Estado = (int)ObtenerEstadoSiguiente();
        }

        public PedidoMiembroView GetMiembroView()
        {
            return new PedidoMiembroView(
                Insumos.SelectMany(x => x.Medios.Select(y => y.Tema)).Distinct().ToList(), 
                CantidadPedido, 
                Fecha, 
                (Estados)Estado, 
                FechaEntregado);
        }

        //TODO: Cambiar DS
        //TODO: Cambiar DC
        private Estados? ObtenerEstadoSiguiente()
        {
            var estado = (Estados)Estado;
            Estados? estadoSiguiente = null;

            if (estado == Estados.Nuevo)
                estadoSiguiente = Estados.Listo;

            if (estado == Estados.Listo)
                estadoSiguiente = Estados.Entregado;

            return estadoSiguiente;
        }

        //TODO: Cambiar DS
        //TODO: Cambiar DC
        private bool PuedeCambiarEstado(string[] roles)
        {
            var estado = (Estados)Estado;
            if (estado == Estados.Nuevo && roles.Contains("Packaging"))
                return true;

            if (estado == Estados.Listo && roles.Contains("Vendedor"))
                return true;

            return false;
        }
    }
}