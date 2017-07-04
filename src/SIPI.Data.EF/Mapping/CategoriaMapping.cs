using SIPI.Core.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SIPI.Data.EF.Mapping
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}