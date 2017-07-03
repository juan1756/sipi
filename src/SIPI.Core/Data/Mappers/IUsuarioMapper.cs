using SIPI.Core.Entidades;

namespace SIPI.Core.Data.Mappers
{
    public interface IUsuarioMapper
    {
        //TODO: Devolver usuario

        Usuario BuscarUsuario(string email, string contrasena);
    }
}