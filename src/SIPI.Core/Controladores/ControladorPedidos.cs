using SIPI.Core.Data;
using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using SIPI.Core.Vistas;
using System;
using System.Linq;

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

        public IPagedCollection<PedidoMiembroView> SeguirPedidosMiembro(string email, int desde, int cantidad)
        {
            return _pedidos
                .ObtenerPedidos(email, desde, cantidad)
                .Convert(x => x.GetMiembroView());
        }

        public IPagedCollection<PedidoOperadorView> SeguirPedidosOperador(string email, string nombreApellidoMiembro, DateTime? fechaDesde, DateTime? fechaHasta, int desde, int cantidad)
        {
            var operador = _usuarios.BuscarUsuario(email) as Operador;

            return _pedidos
                .ObtenerPedidos(operador.Roles.Select(x => x.Nombre).ToArray(), nombreApellidoMiembro, fechaDesde, fechaHasta, desde, cantidad)
                .Convert(x => x.GetOperadorView(operador));
        }

        public void CambiarEstadoPedido(int numero, string email)
        {
            var operador = _usuarios.BuscarUsuario(email) as Operador;
            var pedido = _pedidos.ObtenerPedido(numero);

            pedido.CambiarEstado(operador);

            _dataCtx.Save();
        }

        public void AgregarPedido(string email, int[] idsMediosAudioVisuales, int cantidadCopias)
        {
            var miembro = _usuarios.BuscarUsuario(email) as Miembro;
            var medios = _medios.ObtenerMedios(idsMediosAudioVisuales);
            var pedido = new Pedido(cantidadCopias, miembro);

            foreach (var medio in medios)
            {
                pedido.AgregarMedio(medio);
            }

            _pedidos.Agregar(pedido);
            _dataCtx.Save();
        }
    }
}