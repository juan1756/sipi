using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
