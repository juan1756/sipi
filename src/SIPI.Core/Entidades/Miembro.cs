using System;
using SIPI.Core.Vistas;

namespace SIPI.Core.Entidades
{
    public class Miembro : Usuario
    {
        protected Miembro() : base()
        {
        }

        public int Altura { get; private set; }

        public string Calle { get; private set; }

        public virtual Localidad Localidad { get; private set; }

        public string Telefono { get; private set; }

        public string Piso { get; private set; }

        public virtual Provincia Provincia { get; private set; }

        public override UsuarioView GetView()
        {
            return new MiembroView(Id, Nombre, Apellido, Email, Altura, Calle, Localidad.GetView(), Telefono, Piso, Provincia.GetView());
        }

        public void ConfirmarDireccion(Provincia provincia, Localidad localidad, string calle, int altura, string piso)
        {
            localidad.ValidarProvincia(provincia);

            Provincia = provincia;
            Localidad = localidad;
            Calle = calle;
            Altura = altura;
            Piso = piso;
        }
    }
}