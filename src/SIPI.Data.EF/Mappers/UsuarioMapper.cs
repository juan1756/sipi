using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Linq;
using System;
using SIPI.Core.Data.DTO;
using SIPI.Data.EF.DTO;
using SIPI.Data.EF.Extensions;

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

        public IPagedCollection<Usuario> BuscarUsuarios(IOffsetParams offsetParams)
        {
            return _dbContext.Usuarios
                .OrderBy(x => x.Nombre)
                .ToPagedCollection(offsetParams);
        }
    }
}