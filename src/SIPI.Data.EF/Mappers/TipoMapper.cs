using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Data.EF.Mappers
{
    public class TipoMapper : ITipoMapper
    {
        private readonly DataContext _dbContext;

        public TipoMapper(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Tipo> ObtenerTipos()
        {
            return _dbContext.Tipos.ToList();
        }
    }
}