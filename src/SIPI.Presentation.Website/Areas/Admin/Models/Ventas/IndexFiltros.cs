using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Areas.Admin.Models.Ventas
{
    public class IndexFiltros
    {
        public int? IdCategoria { get; set; }

        public DateTime? Desde { get; set; }

        public DateTime? Hasta { get; set; }
    }
}