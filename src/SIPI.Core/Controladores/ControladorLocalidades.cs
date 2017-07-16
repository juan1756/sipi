using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Core.Controladores
{
    public class ControladorLocalidades
    {
        private readonly ILocalidadMapper _localidades;

        public ControladorLocalidades(ILocalidadMapper localidades)
        {
            _localidades = localidades;
        }

        public IEnumerable<LocalidadView> ObtenerLocalidades()
        {
            return _localidades.ObtenerLocalidades()
                .Select(x => x.GetView())
                .ToList();
        }
    }
}