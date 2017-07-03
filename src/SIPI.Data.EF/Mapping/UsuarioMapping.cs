using SIPI.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Data.EF.Mapping
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            HasKey(x => x.Email);

            Property(x => x.Nombre)
                .IsRequired();

            Property(x => x.Apellido)
                .IsRequired();

            Property(x => x.Contrasena)
                .IsRequired();
        }
    }
}
