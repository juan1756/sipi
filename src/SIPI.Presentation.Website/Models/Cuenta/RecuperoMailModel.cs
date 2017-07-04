namespace SIPI.Presentation.Website.Models.Cuenta
{
    public class RecuperoMailModel
    {
        public RecuperoMailModel(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}