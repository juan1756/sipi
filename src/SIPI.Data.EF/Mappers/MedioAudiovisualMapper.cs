using SIPI.Core.Data.DTO;
using SIPI.Core.Data.Mappers;
using SIPI.Core.Entidades;
using System;
using System.Data.Entity;
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
            fechaDesde = fechaDesde.ConvertFromClientToUTC();
            fechaHasta = fechaHasta?.AddDays(1).ConvertFromClientToUTC();

            var res = _dbCtx.MediosAudiovisuales
                .Include(x => x.Categoria)
                .Include(x => x.Tipo)
                .Where(idCategoria.HasValue, x => x.Categoria.Id == idCategoria)
                .Where(!string.IsNullOrWhiteSpace(tema), x => x.Tema.Contains(tema))
                .Where(fechaDesde.HasValue, x => x.FechaGrabacion >= fechaDesde.Value)
                .Where(fechaHasta.HasValue, x => x.FechaGrabacion <= fechaHasta.Value)
                .Where(idTipo.HasValue, x => x.Tipo.Id == idTipo)
                .OrderByDescending(x => x.FechaGrabacion);

            return res.ToPagedCollection(desde, cantidad);
        }

        public IList<MedioAudiovisual> ObtenerMedios(int[] medios)
        {
            return _dbCtx.MediosAudiovisuales
                .Where(x => medios.Contains(x.Id))
                .ToList();
        }
    }
}