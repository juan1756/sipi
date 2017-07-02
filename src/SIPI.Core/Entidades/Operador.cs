using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Entidades
{
    public class Operador : Usuario
    {
        public virtual Collection<Rol> Roles { get; private set; }
    }
}
