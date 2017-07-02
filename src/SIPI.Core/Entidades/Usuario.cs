using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Entidades
{
    public abstract class Usuario
    {
        public string Email { get; private set; }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Contrasena { get; private set; }

        public abstract UsuarioView GetView();
    }
}
