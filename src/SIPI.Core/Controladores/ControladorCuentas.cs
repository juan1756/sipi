using SIPI.Core.Data;
using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using SIPI.Core.Vistas;
using System.Net;
using System.Net.Mail;
using System;

namespace SIPI.Core.Controladores
{
    public class ControladorCuentas
    {
        private readonly IDataContext _dataCtx;
        private readonly IProvinciaMapper _provincias;
        private readonly ILocalidadMapper _localidades;
        private readonly IUsuarioMapper _usuarios;

        public ControladorCuentas(
            IUsuarioMapper usuarios,
            IProvinciaMapper provincias,
            ILocalidadMapper localidades,
            IDataContext dataCtx)
        {
            _usuarios = usuarios;
            _provincias = provincias;
            _localidades = localidades;
            _dataCtx = dataCtx;
        }

        public UsuarioView IniciarSesion(string email, string contrasena)
        {
            var usuario = _usuarios.BuscarUsuario(email, contrasena);

            if (usuario == null)
                return null;

            return usuario.GetView();
        }

        public void RecuperarContrasena(string email, string contrasena, IRecuperoMailBuilder mail)
        {
            var usuario = _usuarios.BuscarUsuario(email);

            if (usuario == null)
                return;

            var hash = usuario.ActualizarContrasena(contrasena);

            _dataCtx.Save();

            EnviarMailRecupero(usuario, mail.RecuperoMailBody(usuario.GetView(), hash));
        }

        public void RecuperarContrasena(string email, byte[] hashBytes)
        {
            var usuario = _usuarios.BuscarUsuario(email);

            if (usuario == null)
                return;

            usuario.ActualizarContrasena(hashBytes);

            _dataCtx.Save();
        }

        private void EnviarMailRecupero(Usuario usuario, string body)
        {
            var smtp = new SmtpClient();
            var fromAddress = new MailAddress((smtp.Credentials as NetworkCredential).UserName, "Iglesia Calle Brasil");
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
            return _usuarios
                .BuscarUsuarios(nombre, apellido, desde, cantidad)
                .Convert(x => x.GetView());
        }

        public MiembroView BuscarMiembro(string email)
        {
            return _usuarios
                .BuscarUsuario(email)
                .GetView() as MiembroView;
        }

        public void ConfirmarDireccion(string email, int provinciaId, int localidadId, string calle, int altura, string piso)
        {
            var miembro = _usuarios.BuscarUsuario(email) as Miembro;
            var provincia = _provincias.ObtenerProvincia(provinciaId);
            var localidad = _localidades.ObtenerLocalidad(localidadId);

            miembro.ConfirmarDireccion(provincia, localidad, calle, altura, piso);
            _dataCtx.Save();
        }
    }

    public interface IRecuperoMailBuilder
    {
        string RecuperoMailBody(UsuarioView usuario, byte[] hash);
    }
}