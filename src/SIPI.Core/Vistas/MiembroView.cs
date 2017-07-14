namespace SIPI.Core.Vistas
{
    public class MiembroView : UsuarioView
    {
        public MiembroView(int id, string nombre, string apellido, string email, 
            int altura, string calle, string direccion, LocalidadView localidad, string telefono, string piso, ProvinciaView provincia)
            : base(id, nombre, apellido, email)
        {
            Altura = altura;
            Calle = calle;
            Direccion = direccion;
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

        public string Direccion { get; private set; }

        public virtual LocalidadView Localidad { get; private set; }

        public string Telefono { get; private set; }

        public string Piso { get; private set; }

        public virtual ProvinciaView Provincia { get; private set; }
    }
}