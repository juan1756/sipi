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
        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public Collection<Localidad> Localidades { get; private set; }
    }
}
