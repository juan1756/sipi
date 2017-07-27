using System;

namespace SIPI.Core.Entidades
{
    public class Orador
    {
        protected Orador()
        {
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public DateTime FechaCreacion { get; private set; }

        public virtual Operador Operador { get; private set; }
    }
}