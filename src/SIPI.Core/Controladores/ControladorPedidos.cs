using System;
using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;

namespace SIPI.Core.Controladores
{
    public class ControladorPedidos
    {
        private readonly IPedidosMapper _pedidos;

        public ControladorPedidos(IPedidosMapper pedidos)
        {
            _pedidos = pedidos;
        }

        // TODO: Corregir DS
        public IPagedCollection<PedidoMiembroView> SeguirPedidosMiembro(int id, int desde, int cantidad)
        {
            return _pedidos
                .ObtenerPedidos(id, desde, cantidad)
                .Convert(x => x.GetMiembroView());
        }

        public IPagedCollection<PedidoOperadorView> SeguirPedidosOperador(string nombreApellidoMiembro, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            return _pedidos
                .ObtenerPedidos(nombreApellidoMiembro, fechaDesde, fechaHasta, desde, cantidad)
                .Convert(x => x.GetOperadorView());
        }
    }
}