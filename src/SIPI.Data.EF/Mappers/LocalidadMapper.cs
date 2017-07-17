using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace SIPI.Data.EF.Mappers
{
    public class LocalidadMapper : ILocalidadMapper
    {
        private readonly DataContext _dbCtx;

        public LocalidadMapper(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Localidad ObtenerLocalidad(int id)
        {
            return _dbCtx.Localidades.Find(id);
        }

        public IList<Localidad> ObtenerLocalidades()
        {
            return _dbCtx.Localidades
                .Include(x => x.Provincia)
                .ToList();
        }
    }
}