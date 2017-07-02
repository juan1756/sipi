using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Data.Mappers
{
    public interface IUsuarioMapper
    {
        //TODO: Devolver usuario

        Usuario BuscarUsuario(string email, string contrasena);
    }
}
