using SIPI.Core.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Areas.Admin.Models.Ventas
{
    public class IndexModel
    {
        public SelectList Categorias { get; private set; }

        public IndexFiltrosModel Filtros { get; private set; }

        public IndexModel(IEnumerable<CategoriaView> categorias, IndexFiltrosModel filtros)
        {
            Categorias = categorias.ToSelectList(x => x.Id, x => x.Nombre);
            Filtros = filtros;
        }
    }
}