using SIPI.Core.Data;
using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System;

namespace SIPI.Core.Controladores
{
    public class ControladorPedidos
    {
        private readonly IPedidosMapper _pedidos;
        private readonly IDataContext _dataCtx;

        public ControladorPedidos(
            IPedidosMapper pedidos,
            IDataContext dataCtx)
        {
            _pedidos = pedidos;
            _dataCtx = dataCtx;
        }

        // TODO: Corregir DS
        public IPagedCollection<PedidoMiembroView> SeguirPedidosMiembro(int id, int desde, int cantidad)
        {
            return _pedidos
                .ObtenerPedidos(id, desde, cantidad)
                .Convert(x => x.GetMiembroView());
        }

        public IPagedCollection<PedidoOperadorView> SeguirPedidosOperador(string[] roles, string nombreApellidoMiembro, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            return _pedidos
                .ObtenerPedidos(roles, nombreApellidoMiembro, fechaDesde, fechaHasta, desde, cantidad)
                .Convert(x => x.GetOperadorView(roles));
        }

        // TODO: Cambiar DS
        public void CambiarEstadoPedido(int numero, string[] roles)
        {
            var pedido = _pedidos.ObtenerPedido(numero);

            pedido.CambiarEstado(roles);

            _dataCtx.Save();
        }
    }
}