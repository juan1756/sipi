using System;
using System.ComponentModel.DataAnnotations;

namespace SIPI.Presentation.Website.Areas.Admin.Models.Pedidos
{
    public class IndexFiltros
    {
        public string Miembro { get; set; }

        public DateTime? Desde { get; set; }

        public DateTime? Hasta { get; set; }
    }
}