using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Vistas
{
    public class MiembroView : UsuarioView
    {
        public MiembroView(string nombre, string apellido, string email)
            : base(nombre, apellido, email)
        {
        }
    }
}
