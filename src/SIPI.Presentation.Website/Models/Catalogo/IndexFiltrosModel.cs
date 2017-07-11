using System;

namespace SIPI.Presentation.Website.Models.Catalogo
{
    public class IndexFiltrosModel
    {
        public int? CategoriaId { get; set; }

        public string Tema { get; set; }

        public DateTime? FechaDesde { get; set; }

        public DateTime? FechaHasta { get; set; }

        public int? TipoId { get; set; }
    }
}