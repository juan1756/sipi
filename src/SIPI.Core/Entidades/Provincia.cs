using SIPI.Core.Vistas;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SIPI.Core.Entidades
{
    public class Provincia
    {
        protected Provincia()
        {
            Localidades = new Collection<Localidad>();
        }

        public Provincia(int id, string nombre)
            : this()
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public ICollection<Localidad> Localidades { get; private set; }

        public ProvinciaView GetView()
        {
            return new ProvinciaView(Id, Nombre, Localidades.Select(x => x.Id).ToArray());
        }
    }
}