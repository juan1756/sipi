using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _dbContext.Usuarios.Find(email);
        }
    }
}
