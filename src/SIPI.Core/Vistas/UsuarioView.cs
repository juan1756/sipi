namespace SIPI.Core.Vistas
{
    public abstract class UsuarioView
    {
        public UsuarioView(int id, string nombre, string apellido, string email)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public string Apellido { get; private set; }

        public string Email { get; private set; }

        public abstract bool SoyOperador();
    }
}