namespace SIPI.Core.Vistas
{
    public class ReporteVentasPorCategoriaView
    {
        public ReporteVentasPorCategoriaView()
        {
        }

        public ReporteVentasPorCategoriaView(string nombreCategoria, int cantidad)
        {
            NombreCategoria = nombreCategoria;
            Cantidad = cantidad;
        }

        public string NombreCategoria { get; set; }

        public int Cantidad { get; set; }
    }
}