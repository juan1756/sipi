using System;
using System.Collections.Generic;
using static SIPI.Core.Entidades.Pedido;

namespace SIPI.Core.Vistas
{
    public abstract class PedidoSeguimientoView
    {
        protected PedidoSeguimientoView(IList<string> temas, int cantidadPedido, DateTime fechaPedido, Estados estado)
        {
            Temas = temas;
            CantidadPedido = cantidadPedido;
            FechaPedido = fechaPedido;
            Estado = estado;
        }

        public IList<string> Temas { get; private set; }

        public int CantidadPedido { get; private set; }

        public DateTime FechaPedido { get; private set; }

        public Estados Estado { get; private set; }
    }
}