using SIPI.Core.Entidades;

namespace SIPI.Core.Data.Mappers
{
    public interface IUsuarioMapper
    {
        Usuario BuscarUsuario(string email, string contrasena);

        Usuario BuscarUsuario(string email);
    }
}