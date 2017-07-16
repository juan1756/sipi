using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace SIPI.Data.EF.Mappers
{
    public class ProvinciaMapper : IProvinciaMapper
    {
        private readonly DataContext _dbContext;

        public ProvinciaMapper(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Provincia ObtenerProvincia(int id)
        {
            return _dbContext.Provincias.Find(id);
        }

        public IList<Provincia> ObtenerProvincias()
        {
            return _dbContext.Provincias
                .Include(x => x.Localidades)
                .ToList();
        }
    }
}