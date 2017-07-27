using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
        public PedidoOperadorView GetOperadorView(Operador operador)
        {
            return new PedidoOperadorView(
                Numero,
                Insumos.SelectMany(x => x.Medios.Select(y => y.Tema)).Distinct().ToList(),
                $"{Miembro.Nombre} {Miembro.Apellido}",
                CantidadPedido,
                Fecha,
                (Estados)Estado,
                ObtenerEstadoSiguiente(),
                PuedeCambiarEstado(operador));
        }

        // TODO: Cambiar DC
        // TODO: Cambiar DS
        public void CambiarEstado(Operador operador)
        {
            if (!PuedeCambiarEstado(operador))
                throw new UsuarioNoTienePermisosParaModificarEstadoException();

            Estado = (int)ObtenerEstadoSiguiente();

            if (Estado == (int)Estados.Entregado)
            { 
                FechaEntregado = DateTime.Now;
            }
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

        public void AgregarMedio(MedioAudiovisual medio)
        {
            var insumo = ObtenerInsumoParaMedio(medio);

            insumo.AgregarMedio(medio);

            PrecioTotal += Convert.ToDecimal(ConfigurationManager.AppSettings["Insumo.Precio"]);
        }

        private Insumo CrearInsumo()
        {
            var insumo = new Insumo(
                this, 
                numero: Insumos.Count() + 1, 
                precio: Convert.ToDecimal(ConfigurationManager.AppSettings["Insumo.Precio"]), 
                tamano: Convert.ToInt32(ConfigurationManager.AppSettings["Insumo.Tamano"])
            );

            Insumos.Add(insumo);

            return insumo;
        }

        private Insumo ObtenerInsumoParaMedio(MedioAudiovisual medio)
        {
            foreach (var insumo in Insumos)
            {
                if (insumo.SoportaMedio(medio))
                    return insumo;
            }
            return CrearInsumo();
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
        private bool PuedeCambiarEstado(Operador operador)
        {
            var estado = (Estados)Estado;
            if (estado == Estados.Nuevo && operador.TengoRol("Packaging"))
                return true;

            if (estado == Estados.Listo && operador.TengoRol("Vendedor"))
                return true;

            return false;
        }

        public class UsuarioNoTienePermisosParaModificarEstadoException : Exception
        {
            public UsuarioNoTienePermisosParaModificarEstadoException()
                : base("El usuario no tiene permisos para cambiar el estado")
            { }
        }
    }
}