using SIPI.Core.Data.DTO;
using SIPI.Core.Entidades;

namespace SIPI.Core.Data.Mappers
{
    public interface IUsuarioMapper
    {
        Usuario BuscarUsuario(string email, string contrasena);

        Usuario BuscarUsuario(string email);

        IPagedCollection<Usuario> BuscarUsuarios(string nombre, string apellido, int desde, int cantidad);
    }
}