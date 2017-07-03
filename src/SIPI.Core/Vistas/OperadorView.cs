using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Vistas
{
    public class OperadorView : UsuarioView
    {
        public OperadorView(string nombre, string apellido, string email, IList<RolView> roles)
            :base(nombre, apellido, email)
        {
            Roles = roles;
        }

        public IList<RolView> Roles { get; private set; }

        public override bool SoyOperador()
        {
            return true;
        }
    }
}
