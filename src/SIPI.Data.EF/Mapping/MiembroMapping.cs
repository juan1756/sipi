using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Data.EF.Mapping
{
    public class MiembroMapping : EntityTypeConfiguration<Miembro>
    {
        public MiembroMapping()
        {
            Property(x => x.Calle)
                .IsRequired();

            Property(x => x.Direccion)
                .IsRequired();

            Property(x => x.Piso)
                .IsRequired();

            Property(x => x.Telefono)
                .IsRequired();

            HasRequired(x => x.Localidad);
            HasRequired(x => x.Provincia);
        }
    }
}
