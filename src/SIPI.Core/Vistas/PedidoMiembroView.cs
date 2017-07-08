using System;
using System.Collections.Generic;
using static SIPI.Core.Entidades.Pedido;

namespace SIPI.Core.Vistas
{
    public class PedidoMiembroView : PedidoSeguimientoView
    {
        public PedidoMiembroView(IList<string> temas, int cantidadPedido, DateTime fechaPedido, Estados estado, DateTime? fechaEntregado)
            : base(temas, cantidadPedido, fechaPedido, estado)
        {
            FechaEntregado = fechaEntregado;
        }

        public DateTime? FechaEntregado { get; private set; }
    }
}