using System.Collections.Generic;

namespace SIPI.Core.Vistas
{
    public class OperadorView : UsuarioView
    {
        public OperadorView(int id, string nombre, string apellido, string email, IList<RolView> roles)
            : base(id, nombre, apellido, email)
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