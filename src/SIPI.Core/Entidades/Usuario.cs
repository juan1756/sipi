using SIPI.Core.Servicios;
using SIPI.Core.Vistas;
using System;

namespace SIPI.Core.Entidades
{
    public abstract class Usuario
    {
        protected Usuario()
        {
        }

        protected Usuario(int id, string email, string nombre, string apellido, string contrasena)
        {
            Id = id;
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = contrasena;
        }

        public int Id { get; private set; }

        public string Email { get; private set; }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Contrasena { get; private set; }

        public string ContrasenaNueva { get; private set; }

        public string Hash { get; private set; }

        public abstract UsuarioView GetView();

        public bool ContrasenaValida(string contrasena)
        {
            return Contrasena == contrasena;
        }

        public byte[] ActualizarContrasena(string contrasena)
        {
            ContrasenaNueva = contrasena;
            var hashBytes = Hashing.Hash(Guid.NewGuid().ToString());
            Hash = Hashing.HexStringFromHashBytes(hashBytes);
            return hashBytes;
        }

        public void ActualizarContrasena(byte[] hashBytes)
        {
            if (Hash != Hashing.HexStringFromHashBytes(hashBytes))
                return;

            Contrasena = ContrasenaNueva;
            ContrasenaNueva = null;
            Hash = null;
        }
    }
}