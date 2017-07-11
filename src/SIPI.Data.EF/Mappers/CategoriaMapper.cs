using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Data.EF.Mappers
{
    public class CategoriaMapper : ICategoriaMapper
    {
        private readonly DataContext _dbContext;

        public CategoriaMapper(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Categoria> ObtenerCategorias()
        {
            return _dbContext.Categorias.ToList();
        }
    }
}