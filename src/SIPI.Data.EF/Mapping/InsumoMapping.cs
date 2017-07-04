using SIPI.Core.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SIPI.Data.EF.Mapping
{
    public class InsumoMapping : EntityTypeConfiguration<Insumo>
    {
        public InsumoMapping()
        {
            HasKey(x => new { x.PedidoNumero, x.Numero });
            HasMany(x => x.Medios).WithMany();
        }
    }
}