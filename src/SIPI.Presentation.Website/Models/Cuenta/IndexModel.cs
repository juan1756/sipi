using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class IndexModel
    {
        public ICollection<CategoriaView> Categorias { get; set; }

        public IndexFiltersModel Filters { get; set; }
    }

    public class IndexFiltersModel
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }
    }
}