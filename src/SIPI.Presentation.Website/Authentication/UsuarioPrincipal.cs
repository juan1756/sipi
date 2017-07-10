using System;
using System.Linq;
using System.Security.Principal;

namespace SIPI.Presentation.Website.Authentication
{
    public interface ICustomPrincipalData
    {
        int Id { get; }

        string Nombre { get; }

        string Apellido { get; }

        string[] Roles { get; }
    }

    public interface ICustomPrincipal : ICustomPrincipalData, IPrincipal { }

    public class CustomPrincipal : ICustomPrincipal
    {
        public CustomPrincipal(string email, ICustomPrincipalData data)
        {
            Identity = new GenericIdentity(email);
            Id = data.Id;
            Nombre = data.Nombre;
            Apellido = data.Apellido;
            Roles = data.Roles;
        }

        public int Id { get; private set; }

        public string Apellido { get; private set; }

        public string Nombre { get; private set; }

        public IIdentity Identity { get; private set; }

        public string[] Roles { get; private set; }

        public bool IsInRole(string role)
        {
            return Roles.Any(x => x.Equals(role, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class CustomPrincipalData : ICustomPrincipalData
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string[] Roles { get; set; }
    }
}