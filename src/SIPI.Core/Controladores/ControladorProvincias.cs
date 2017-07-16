using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Core.Controladores
{
    public class ControladorProvincias
    {
        private readonly IProvinciaMapper _provincias;

        public ControladorProvincias(IProvinciaMapper provincias)
        {
            _provincias = provincias;
        }

        public IEnumerable<ProvinciaView> ObtenerProvincias()
        {
            return _provincias.ObtenerProvincias()
                .Select(x => x.GetView())
                .ToList();
        }
    }
}