using SIPI.Core.Entidades;
using System.Collections.Generic;

namespace SIPI.Core.Data.Mappers
{
    public interface ILocalidadMapper
    {
        IList<Localidad> ObtenerLocalidades();
        Localidad ObtenerLocalidad(int localidadId);
    }
}