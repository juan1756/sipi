using SIPI.Core.Data;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using SIPI.Core.Vistas;
using System;
using System.Net;
using System.Net.Mail;

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
            var usuario = _mapper.BuscarUsuario(email);

            if (usuario == null)
                return null;

            if (!usuario.ContrasenaValida(contrasena))
                return null;

            return usuario.GetView();
        }

        public bool RecuperarContrasena(string email, string contrasena, byte[] hashBytes)
        {
            var usuario = _mapper.BuscarUsuario(email);

            if (usuario == null)
                return false;

            usuario.ActualizarContrasena(contrasena, hashBytes);

            _dataCtx.Save();

            return true;
        }

        public void RecuperarContrasena(string email, Func<byte[], string> emailBodyFactory)
        {
            var usuario = _mapper.BuscarUsuario(email);

            if (usuario == null)
                return;

            var hash = usuario.GenerarRecuperoContrasena();

            EnviarMailRecupero(usuario, emailBodyFactory(hash));

            _dataCtx.Save();
        }

        private void EnviarMailRecupero(Usuario usuario, string body)
        {
            var smtp = new SmtpClient();
            var fromAddress = new MailAddress((smtp.Credentials as NetworkCredential).UserName);
            var toAddress = new MailAddress(usuario.Email, $"{usuario.Nombre} {usuario.Apellido}");

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Recupero contraseña",
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}