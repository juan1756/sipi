namespace SIPI.Core.Vistas
{
    public class MiembroView : UsuarioView
    {
        public MiembroView(int id, string nombre, string apellido, string email)
            : base(id, nombre, apellido, email)
        {
        }

        public override bool SoyOperador()
        {
            return false;
        }
    }
}