using SIPI.Core.Vistas;

namespace SIPI.Core.Entidades
{
    public class Tipo
    {
        private Tipo()
        {
        }

        public Tipo(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public TipoView GetView()
        {
            return new TipoView(Id, Nombre);
        }
    }
}