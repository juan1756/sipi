using SIPI.Core.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SIPI.Data.EF.Mapping
{
    public class LocalidadMapping : EntityTypeConfiguration<Localidad>
    {
        public LocalidadMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Nombre)
                .IsRequired();

            HasRequired(x => x.Provincia);
        }
    }
}