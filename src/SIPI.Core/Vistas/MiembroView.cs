using SIPI.Core.Entidades;
using System;

namespace SIPI.Core.Vistas
{
    public class MiembroView : UsuarioView
    {
        public MiembroView(int id, string nombre, string apellido, string email, 
            int altura, string calle, LocalidadView localidad, string telefono, string piso, ProvinciaView provincia)
            : base(id, nombre, apellido, email)
        {
            Altura = altura;
            Calle = calle;
            Localidad = localidad;
            Telefono = telefono;
            Piso = piso;
            Provincia = provincia;

        }

        public override bool SoyOperador()
        {
            return false;
        }

        public int Altura { get; private set; }

        public string Calle { get; private set; }

        public virtual LocalidadView Localidad { get; private set; }

        public string Telefono { get; private set; }

        public string Piso { get; private set; }

        public virtual ProvinciaView Provincia { get; private set; }
    }
}