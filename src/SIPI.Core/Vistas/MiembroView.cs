namespace SIPI.Core.Vistas
{
    public class MiembroView : UsuarioView
    {
        public MiembroView(string nombre, string apellido, string email)
            : base(nombre, apellido, email)
        {
        }

        public override bool SoyOperador()
        {
            return false;
        }
    }
}