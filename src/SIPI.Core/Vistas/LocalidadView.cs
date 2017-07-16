namespace SIPI.Core.Vistas
{
    public class LocalidadView
    {
        public LocalidadView(int id, string nombre, int provinciaId)
        {
            Id = id;
            Nombre = nombre;
            ProvinciaId = provinciaId;
        }

        public int Id { get; private set; }

        public string Nombre { get; private set; }

        public int ProvinciaId { get; private set; }
    }
}