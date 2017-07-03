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
        private Operador() : base()
        {
            Roles = new Collection<Rol>();
        }

        public Operador(string email, string nombre, string apellido, string contrasena, Rol rol)
            :base(email, nombre, apellido, contrasena)
        {
            Roles = new Collection<Rol>();
            Roles.Add(rol);
        }

        public virtual ICollection<Rol> Roles { get; private set; }

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
