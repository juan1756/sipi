using SIPI.Core.Entidades;
using System.Collections.Generic;

namespace SIPI.Core.Data.Mappers
{
    public interface ITipoMapper
    {
        IList<Tipo> GetTipos();
    }
}