using SIPI.Core.Data;
using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using SIPI.Core.Vistas;
using System;
using System.Net;
using System.Net.Mail;

namespace SIPI.Core.Controladores
{
    public class ControladorCuentas
    {
        private readonly IDataContext _dataCtx;
        private readonly IUsuarioMapper _mapper;

        public ControladorCuentas(
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

        // TODO: Actualizar DS
        public void RecuperarContrasena(string email, string contrasena, IRecuperoMailBuilder mail)
        {
            var usuario = _mapper.BuscarUsuario(email);

            if (usuario == null)
                return;

            var hash = usuario.ActualizarContrasena(contrasena);

            _dataCtx.Save();

            EnviarMailRecupero(usuario, mail.RecuperoMailBody(usuario.GetView(), hash));
        }

        // TODO: Actualizar DS
        public void RecuperarContrasena(string email, byte[] hashBytes)
        {
            var usuario = _mapper.BuscarUsuario(email);

            if (usuario == null)
                return;

            usuario.ActualizarContrasena(hashBytes);

            _dataCtx.Save();
        }

        // TODO: Actualizar DS
        private void EnviarMailRecupero(Usuario usuario, string body)
        {
            var smtp = new SmtpClient();
            var fromAddress = new MailAddress((smtp.Credentials as NetworkCredential).UserName);
            var toAddress = new MailAddress(usuario.Email, $"{usuario.Nombre} {usuario.Apellido}");

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Recupero contraseña",
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }

        public IPagedCollection<UsuarioView> BuscarUsuarios(string nombre, string apellido, int desde, int cantidad)
        {
            return _mapper
                .BuscarUsuarios(nombre, apellido, desde, cantidad)
                .Convert(x => x.GetView());
        }
    }

    public interface IRecuperoMailBuilder
    {
        string RecuperoMailBody(UsuarioView usuario, byte[] hash);
    }
}