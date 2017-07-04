using System;

namespace SIPI.Core.Entidades
{
    public class Orador
    {
        private Orador()
        {
        }

        public Orador(int id, string nombre, string apellido, Operador operador)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaCreacion = DateTime.Now;
            Operador = operador;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public DateTime FechaCreacion { get; private set; }

        public virtual Operador Operador { get; private set; }
    }
}