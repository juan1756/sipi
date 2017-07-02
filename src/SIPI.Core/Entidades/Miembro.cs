using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Core.Entidades
{
    public class Miembro : Usuario
    {
        public int Altura { get; private set; }

        public string Calle { get; private set; }

        public string Direccion { get; private set; }

        public virtual Localidad Localidad { get; private set; }

        public string Telefono { get; private set; }

        public string Piso { get; private set; }

        public virtual Provincia Provincia { get; private set; }
    }
}
