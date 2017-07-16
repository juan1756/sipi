namespace SIPI.Core.Vistas
{
    public class ProvinciaView
    {
        public ProvinciaView(int id, string nombre, int[] localidades)
        {
            Id = id;
            Nombre = nombre;
            Localidades = localidades;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public int[] Localidades { get; private set; }
    }
}