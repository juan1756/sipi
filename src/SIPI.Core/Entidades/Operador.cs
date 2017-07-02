using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIPI.Core.Vistas;

namespace SIPI.Core.Entidades
{
    public class Operador : Usuario
    {
        public virtual Collection<Rol> Roles { get; private set; }

        public override UsuarioView GetView()
        {
            return new OperadorView(
                Nombre, 
                Apellido, 
                Email, 
                Roles.Select(x => x.GetView()).ToList());
        }
    }
}
