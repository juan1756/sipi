using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Areas.Admin.Models.Ventas
{
    public class IndexFiltrosModel
    {
        public int? IdCategoria { get; set; }

        public DateTime? FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }
    }
}