using SIPI.Core.Data.DTO;
using SIPI.Core.Vistas;
using SIPI.Presentation.Website.Models.Shared;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SIPI.Presentation.Website.Models.Catalogo
{
    public class IndexModel
    {
        public SelectList Categorias { get; private set; }

        public SelectList Tipos { get; private set; }

        public IndexFiltrosModel Filtros { get; private set; }

        public IPagedCollection<MedioAudiovisualView> Medios { get; private set; }

        public OffsetParams OffsetParams { get; private set; }

        public IndexModel(
            IEnumerable<CategoriaView> categorias,
            IEnumerable<TipoView> tipos,
            IndexFiltrosModel filtros,
            IPagedCollection<MedioAudiovisualView> medios,
            OffsetParams offsetParams)
        {
            Categorias = categorias.ToSelectList(x => x.Id, x => x.Nombre);
            Tipos = tipos.ToSelectList(x => x.Id, x => x.Nombre);
            Filtros = filtros;
            Medios = medios;
            OffsetParams = offsetParams;
        }
    }
}