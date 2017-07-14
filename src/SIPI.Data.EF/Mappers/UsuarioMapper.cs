using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Linq;

namespace SIPI.Data.EF.Mappers
{
    public class UsuarioMapper : IUsuarioMapper
    {
        private readonly DataContext _dbContext;

        public UsuarioMapper(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario BuscarUsuario(string email, string contrasena)
        {
            return _dbContext.Usuarios
                .Where(x => x.Email == email)
                .Where(x => x.Contrasena == contrasena)
                .SingleOrDefault();
        }

        public Usuario BuscarUsuario(string email)
        {
            return _dbContext.Usuarios
                .Where(x => x.Email == email)
                .SingleOrDefault();
        }

        public IPagedCollection<Usuario> BuscarUsuarios(string nombre, string apellido, int desde, int cantidad)
        {
            return _dbContext.Usuarios
                .Where(!string.IsNullOrWhiteSpace(nombre), x => x.Nombre.Contains(nombre))
                .Where(!string.IsNullOrWhiteSpace(apellido), x => x.Apellido.Contains(apellido))
                .OrderBy(x => x.Nombre)
                .ToPagedCollection(desde, cantidad);
        }
    }
}