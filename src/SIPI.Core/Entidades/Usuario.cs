using System;
using SIPI.Core.Vistas;
using SIPI.Core.Servicios;
using System.Text;

namespace SIPI.Core.Entidades
{
    public abstract class Usuario
    {
        protected Usuario()
        {
        }

        protected Usuario(string email, string nombre, string apellido, string contrasena)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = GenerarContrasena(contrasena);
        }

        public string Email { get; private set; }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Contrasena { get; private set; }

        public string Hash { get; private set; }

        public abstract UsuarioView GetView();

        public bool ContrasenaValida(string contrasena)
        {
            return Contrasena == GenerarContrasena(contrasena);
        }

        public void ActualizarContrasena(string constrasena, byte[] hashBytes)
        {
            var hash = Hashing.HexStringFromHashBytes(hashBytes);

            if (Hash != hash)
                throw new Exception("No se puede modificar la contraseña del usuario");

            Hash = null;
            Contrasena = GenerarContrasena(constrasena);
        }

        public byte[] GenerarRecuperoContrasena()
        {
            var hashBytes = Hashing.Hash(Guid.NewGuid().ToString());
            Hash = Hashing.HexStringFromHashBytes(hashBytes);
            return hashBytes;
        }

        private string GenerarContrasena(string contrasena)
        {
            return Hashing.HashToString(contrasena);
        }
    }
}