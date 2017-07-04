using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Linq;
using System;

namespace SIPI.Data.EF.Mappers
{
    public class UsuarioMapper : IUsuarioMapper
    {
        private readonly DataContext _dbContext;

        public UsuarioMapper(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario BuscarUsuario(string email)
        {
            return _dbContext.Usuarios.Find(email);
        }

        public Usuario BuscarUsuario(string email, string contrasena)
        {
            return _dbContext.Usuarios
                .Where(x => x.Email == email)
                .Where(x => x.Contrasena == contrasena)
                .SingleOrDefault();
        }
    }
}