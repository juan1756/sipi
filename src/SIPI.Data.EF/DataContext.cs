using SIPI.Core.Data;
using SIPI.Core.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace SIPI.Data.EF
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("SIPI")
        {
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Localidad> Localidades { get; set; }

        public DbSet<MedioAudiovisual> MediosAudiovisuales { get; set; }

        public DbSet<Orador> Oradores { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Tipo> Tipos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public IQueryable<Operador> Operadores
        {
            get
            {
                return Usuarios.OfType<Operador>();
            }
        }

        public IQueryable<Miembro> Miembros
        {
            get
            {
                return Usuarios.OfType<Miembro>();
            }
        }

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