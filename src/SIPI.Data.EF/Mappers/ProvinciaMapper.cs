using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Data.EF.Mappers
{
    public class ProvinciaMapper : IProvinciaMapper
    {
        private readonly DataContext _dbContext;

        public ProvinciaMapper(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Provincia> GetProvincias()
        {
            return _dbContext.Provincias.ToList();
        }
    }
}