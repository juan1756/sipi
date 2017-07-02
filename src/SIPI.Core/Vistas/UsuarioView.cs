using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Vistas
{
    public abstract class UsuarioView
    {
        public UsuarioView(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Email { get; private set; }
    }
}
