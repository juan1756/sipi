namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class RecuperoMailModel
    {
        public RecuperoMailModel(string email, string token, string nombre, string apellido)
        {
            Email = email;
            Token = token;
            Nombre = nombre;
            Apellido = apellido;
        }

        public string Email { get; private set; }

        public string Token { get; private set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
    }
}