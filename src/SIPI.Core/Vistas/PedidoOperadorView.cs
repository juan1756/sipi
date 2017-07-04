using System;
using static SIPI.Core.Entidades.Pedido;

namespace SIPI.Core.Vistas
{
    public class PedidoOperadorView : PedidoSeguimientoView
    {
        public PedidoOperadorView(int numero, string tema, string miembro, int cantidadPedido, DateTime fechaPedido, Estados estado, Estados estadoSiguiente)
            : base(tema, cantidadPedido, fechaPedido, estado)
        {
            Numero = numero;
            Miembro = miembro;
            EstadoSiguiente = estadoSiguiente;
        }

        public int Numero { get; private set; }

        public string Miembro { get; private set; }

        public Estados EstadoSiguiente { get; private set; }
    }
}