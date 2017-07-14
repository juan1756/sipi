using SIPI.Core.Data.DTO;
using SIPI.Core.Entidades;
using System;

namespace SIPI.Core.Data.Mappers
{
    public interface IMedioAudiovisualMapper
    {
        IPagedCollection<MedioAudiovisual> ObtenerCatalogo(int? idCategoria, string tema, DateTime? fechaDesde, DateTime? fechaHasta, int? idTipo, int desde, int cantidad);
    }
}