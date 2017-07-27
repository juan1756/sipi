using SIPI.Core.Vistas;
using System;

namespace SIPI.Core.Entidades
{
    public class Categoria
    {
        protected Categoria()
        {
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public DateTime FechaCreacion { get; private set; }

        public virtual Operador Operador { get; private set; }

        public CategoriaView GetView()
        {
            return new CategoriaView(Id, Nombre);
        }
    }
}