using SIPI.Core.Data.Mappers;
using SIPI.Core.Vistas;
using System.Collections.Generic;
using System.Linq;

namespace SIPI.Core.Controladores
{
    public class ControladorCategorias
    {
        private readonly ICategoriaMapper _categorias;

        public ControladorCategorias(ICategoriaMapper categorias)
        {
            _categorias = categorias;
        }

        public IEnumerable<CategoriaView> ObtenerCategorias()
        {
            return _categorias.ObtenerCategorias()
                .Select(x => x.GetView())
                .ToList();
        }
    }
}