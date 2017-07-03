using SIPI.Core.Data;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System;

namespace SIPI.Core.Controladores
{
    public class CuentaControlador
    {
        private readonly IDataContext _dataCtx;
        private readonly IUsuarioMapper _mapper;

        public CuentaControlador(
            IUsuarioMapper mapper,
            IDataContext dataCtx)
        {
            _mapper = mapper;
            _dataCtx = dataCtx;
        }

        public UsuarioView IniciarSesion(string email, string contrasena)
        {
            var usuario = _mapper.BuscarUsuario(email, contrasena);

            if (usuario == null)
                return null;

            return usuario.GetView();
        }

        public void RecuperarContrasena(string email)
        {
            throw new NotImplementedException();
        }
    }
}