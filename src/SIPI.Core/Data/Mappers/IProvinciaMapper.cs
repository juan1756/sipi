using SIPI.Core.Entidades;
using System.Collections.Generic;

namespace SIPI.Core.Data.Mappers
{
    public interface IProvinciaMapper
    {
        IList<Provincia> ObtenerProvincias();
        Provincia ObtenerProvincia(int provinciaId);
    }
}