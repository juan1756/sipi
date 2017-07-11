using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Core.Controladores
{
    public class ControladorTipos
    {
        private readonly ITipoMapper _tipos;

        public ControladorTipos(ITipoMapper tipos)
        {
            _tipos = tipos;
        }

        public IEnumerable<TipoView> ObtenerTipos()
        {
            return _tipos.ObtenerTipos()
                .Select(x => x.GetView())
                .ToList();
        }
    }
}