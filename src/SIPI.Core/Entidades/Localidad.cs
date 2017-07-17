using SIPI.Core.Vistas;
using System;

namespace SIPI.Core.Entidades
{
    public class Localidad
    {
        protected Localidad()
        {
        }

        public Localidad(int id, string nombre, Provincia provincia)
        {
            Id = id;
            Nombre = nombre;
            Provincia = provincia;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public virtual Provincia Provincia { get; private set; }

        public LocalidadView GetView()
        {
            return new LocalidadView(Id, Nombre, Provincia.Id);
        }

        public void ValidarProvincia(Provincia provincia)
        {
            if (Provincia.Id != provincia.Id)
                throw new LocalidadNoPerteneceAProvinciaException();
        }

        public class LocalidadNoPerteneceAProvinciaException : Exception
        {
            public LocalidadNoPerteneceAProvinciaException()
                : base("La localidad o la provincia son inválidas")
            { }
        }
    }
}