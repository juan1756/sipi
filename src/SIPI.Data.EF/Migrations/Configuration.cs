namespace SIPI.Data.EF.Migrations
{
    using Core.Entidades;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.

            //var provincias_BuenosAires = new Provincia(1, "Buenos Aires");

            //context.Provincias.AddOrUpdate(x => x.Id,
            //    provincias_BuenosAires
            //);

            //var localidades_BuenosAires = new Localidad(1, "Buenos Aires", provincias_BuenosAires);
            //var localidades_LaPlata = new Localidad(2, "La Plata", provincias_BuenosAires);

            //context.Localidades.AddOrUpdate(x => x.Id,
            //    localidades_BuenosAires,
            //    localidades_LaPlata
            //);

            //var roles_operador_contenido = new Rol(1, "Contenido", "Lorem ipsum dolo e amet");
            //var roles_operador_packaging = new Rol(2, "Packaging", "Lorem ipsum dolo e amet");
            //var roles_operador_vendedor = new Rol(3, "Vendedor", "Lorem ipsum dolo e amet");

            //context.Roles.AddOrUpdate(x => x.Id,
            //    roles_operador_contenido,
            //    roles_operador_packaging,
            //    roles_operador_vendedor
            //);

            //var miembro = new Miembro(1, "miembro@mail.com", "Don", "Miembro", "1234", "Charcas", "Direccion", 4792, "1", "47760626", localidades_BuenosAires, provincias_BuenosAires);
            //var operador_contenido = new Operador(2, "operador_contenido@mail.com", "Don", "Operador Contenido", "1234", roles_operador_contenido);
            //var operador_packaging = new Operador(3, "operador_packaging@mail.com", "Don", "Operador Packaging", "1234", roles_operador_packaging);
            //var operador_vendedor = new Operador(4, "operador_vendedor@mail.com", "Don", "Operador Vendedor", "1234", roles_operador_vendedor);

            //context.Usuarios.AddOrUpdate(x => x.Id,
            //    miembro, 
            //    operador_contenido, 
            //    operador_packaging, 
            //    operador_vendedor
            //);

            //context.SaveChanges();
        }
    }
}