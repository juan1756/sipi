using System;
using SIPI.Core.Vistas;

namespace SIPI.Core.Entidades
{
    public class Miembro : Usuario
    {
        protected Miembro() : base()
        {
        }

        public Miembro(int id, string email, string nombre, string apellido, string contrasena,
            string calle, string direccion, int altura, string piso, string telefono, Localidad localidad, Provincia provincia)
            : base(id, email, nombre, apellido, contrasena)
        {
            Calle = calle;
            Altura = altura;
            Piso = piso;
            Telefono = telefono;
            Localidad = localidad;
            Provincia = provincia;
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