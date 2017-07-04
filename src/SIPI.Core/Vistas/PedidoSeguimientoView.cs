using System;
using static SIPI.Core.Entidades.Pedido;

namespace SIPI.Core.Vistas
{
    public abstract class PedidoSeguimientoView
    {
        protected PedidoSeguimientoView(string tema, int cantidadPedido, DateTime fechaPedido, Estados estado)
        {
            Tema = tema;
            CantidadPedido = cantidadPedido;
            FechaPedido = fechaPedido;
            Estado = estado;
        }

        public string Tema { get; private set; }

        public int CantidadPedido { get; private set; }

        public DateTime FechaPedido { get; private set; }

        public Estados Estado { get; private set; }
    }
}