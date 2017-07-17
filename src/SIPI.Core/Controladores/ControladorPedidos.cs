using SIPI.Core.Data;
using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using SIPI.Core.Vistas;
using System;

namespace SIPI.Core.Controladores
{
    public class ControladorPedidos
    {
        private readonly IPedidosMapper _pedidos;
        private readonly IUsuarioMapper _usuarios;
        private readonly IMedioAudiovisualMapper _medios;
        private readonly IDataContext _dataCtx;

        public ControladorPedidos(
            IPedidosMapper pedidos,
            IUsuarioMapper usuarios,
            IMedioAudiovisualMapper medios,
            IDataContext dataCtx)
        {
            _pedidos = pedidos;
            _usuarios = usuarios;
            _medios = medios;
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

        public void AgregarPedido(string email, int[] idsMediosAudioVisuales, int cantidadCopias)
        {
            var miembro = _usuarios.BuscarUsuario(email) as Miembro;
            var pedido = new Pedido(cantidadCopias, miembro);
            var medios = _medios.ObtenerMedios(idsMediosAudioVisuales);

            foreach (var medio in medios)
            {
                pedido.AgregarMedio(medio);
            }

            _pedidos.Agregar(pedido);
            _dataCtx.Save();
        }
    }
}