using SIPI.Core.Data;
using SIPI.Core.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SIPI.Data.EF
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("SIPI")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Localidad> Localidades { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.IsUnicode(false).HasMaxLength(150));

            RegisterMappings(modelBuilder);

            modelBuilder.Entity<Operador>().HasMany(x => x.Roles).WithMany();
        }

        private void RegisterMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        void IDataContext.Save()
        {
            SaveChanges();
        }
    }
}