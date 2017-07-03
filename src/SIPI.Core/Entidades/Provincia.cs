using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Entidades
{
    public class Provincia
    {
        private Provincia()
        {
            Localidades = new Collection<Localidad>();
        }

        public Provincia(int id, string nombre)
            :this()
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public ICollection<Localidad> Localidades { get; private set; }
    }
}
