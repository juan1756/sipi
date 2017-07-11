using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIPI.Presentation.Website.Areas.Admin.Models.Ventas
{
    public class IndexModel
    {
        public IndexFiltersModel Filters { get; set; }
    }

    public class IndexFiltersModel
    {
        public int IdCategoria{ get; set; }

        public DateTime? FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }
    }
}