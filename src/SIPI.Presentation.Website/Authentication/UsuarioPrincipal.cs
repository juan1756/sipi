using SIPI.Core.Vistas;
using System.Security.Principal;
using System.Web;

namespace SIPI.Presentation.Website.Authentication
{
    public class UsuarioPrincipal : GenericPrincipal
    {
        public UsuarioPrincipal(IIdentity identity, string[] roles, UsuarioView usuario)
            :base(identity, roles)
        {
            Usuario = usuario;
        }

        public UsuarioView Usuario { get; private set; }

        public static UsuarioPrincipal Actual { get { return HttpContext.Current.User as UsuarioPrincipal; } }
    }

}