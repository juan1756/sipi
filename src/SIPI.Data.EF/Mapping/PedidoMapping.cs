using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
