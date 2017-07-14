using SIPI.Core.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SIPI.Data.EF.Mapping
{
    public class MedioAudiovisualMapping : EntityTypeConfiguration<MedioAudiovisual>
    {
        public MedioAudiovisualMapping()
        {
            Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(5000);

            HasRequired(x => x.Categoria);
        }
    }
}