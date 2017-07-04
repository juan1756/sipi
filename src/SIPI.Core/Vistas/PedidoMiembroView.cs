using System;
using static SIPI.Core.Entidades.Pedido;

namespace SIPI.Core.Vistas
{
    public class PedidoMiembroView : PedidoSeguimientoView
    {
        public PedidoMiembroView(string tema, int cantidadPedido, DateTime fechaPedido, Estados estado, DateTime? fechaEntregado)
            : base(tema, cantidadPedido, fechaPedido, estado)
        {
            FechaEntregado = fechaEntregado;
        }

        public DateTime? FechaEntregado { get; private set; }
    }
}