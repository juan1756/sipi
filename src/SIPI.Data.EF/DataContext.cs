using SIPI.Core.Entidades;
using SIPI.Data.EF.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPI.Data.EF
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("SIPI")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Localidad> Localidades { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(p => p.IsUnicode(false).HasMaxLength(100));

            RegisterMappings(modelBuilder);
        }

        private void RegisterMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMapping());
        }
    }
}
