using SIPI.Core.Entidades;
using System.Collections.Generic;

namespace SIPI.Core.Data.Mappers
{
    public interface ICategoriaMapper
    {
        IList<Categoria> ObtenerCategorias();
    }
}