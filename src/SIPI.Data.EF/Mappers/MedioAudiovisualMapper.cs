using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SIPI.Data.EF.Mappers
{
    public class MedioAudiovisualMapper : IMedioAudiovisualMapper
    {
        private readonly DataContext _dbCtx;

        public MedioAudiovisualMapper(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public IPagedCollection<MedioAudiovisual> ObtenerCatalogo(int? idCategoria, string tema, DateTime? fechaDesde, DateTime? fechaHasta, int? idTipo, int desde, int cantidad)
        {
            return _dbCtx.MediosAudiovisuales
                .Where(idCategoria.HasValue, x => x.Categoria.Id == idCategoria)
                .Where(!string.IsNullOrWhiteSpace(tema), x => x.Tema.Contains(tema))
                .Where(fechaDesde.HasValue, x => fechaDesde <= x.FechaGrabacion)
                .Where(fechaHasta.HasValue, x => x.FechaGrabacion <= fechaHasta)
                .Where(idTipo.HasValue, x => x.Tipo.Id == idTipo)
                .OrderByDescending(x => x.FechaGrabacion)
                .ToPagedCollection(desde, cantidad);
        }
    }
}