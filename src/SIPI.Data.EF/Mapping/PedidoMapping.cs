using SIPI.Core.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SIPI.Data.EF.Mapping
{
    public class PedidoMapping : EntityTypeConfiguration<Pedido>
    {
        public PedidoMapping()
        {
            HasKey(x => x.Numero);
            HasRequired(x => x.Miembro);
            HasMany(x => x.Insumos).WithRequired(x => x.Pedido);
        }
    }
}