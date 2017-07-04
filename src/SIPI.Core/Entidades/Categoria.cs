using System;

namespace SIPI.Core.Entidades
{
    public class Categoria
    {
        private Categoria()
        {
        }

        public Categoria(int id, string nombre, Operador operador)
        {
            Id = id;
            Nombre = nombre;
            FechaCreacion = DateTime.Now;
            Operador = operador;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public DateTime FechaCreacion { get; private set; }

        public virtual Operador Operador { get; private set; }
    }
}