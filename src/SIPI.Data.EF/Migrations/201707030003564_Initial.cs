namespace SIPI.Data.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localidad",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Nombre = c.String(nullable: false, maxLength: 150, unicode: false),
                    Provincia_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_Id)
                .Index(t => t.Provincia_Id);

            CreateTable(
                "dbo.Provincia",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Nombre = c.String(nullable: false, maxLength: 150, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Rol",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Nombre = c.String(nullable: false, maxLength: 150, unicode: false),
                    Descripcion = c.String(nullable: false, maxLength: 500, unicode: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Usuario",
                c => new
                {
                    Email = c.String(nullable: false, maxLength: 150, unicode: false),
                    Nombre = c.String(nullable: false, maxLength: 150, unicode: false),
                    Apellido = c.String(nullable: false, maxLength: 150, unicode: false),
                    Contrasena = c.String(nullable: false, maxLength: 150, unicode: false),
                    Altura = c.Int(),
                    Calle = c.String(maxLength: 150, unicode: false),
                    Direccion = c.String(maxLength: 150, unicode: false),
                    Telefono = c.String(maxLength: 150, unicode: false),
                    Piso = c.String(maxLength: 150, unicode: false),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                    Localidad_Id = c.Int(),
                    Provincia_Id = c.Int(),
                })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Localidad", t => t.Localidad_Id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_Id)
                .Index(t => t.Localidad_Id)
                .Index(t => t.Provincia_Id);

            CreateTable(
                "dbo.OperadorRol",
                c => new
                {
                    Operador_Email = c.String(nullable: false, maxLength: 150, unicode: false),
                    Rol_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Operador_Email, t.Rol_Id })
                .ForeignKey("dbo.Usuario", t => t.Operador_Email)
                .ForeignKey("dbo.Rol", t => t.Rol_Id)
                .Index(t => t.Operador_Email)
                .Index(t => t.Rol_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.OperadorRol", "Rol_Id", "dbo.Rol");
            DropForeignKey("dbo.OperadorRol", "Operador_Email", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Provincia_Id", "dbo.Provincia");
            DropForeignKey("dbo.Usuario", "Localidad_Id", "dbo.Localidad");
            DropForeignKey("dbo.Localidad", "Provincia_Id", "dbo.Provincia");
            DropIndex("dbo.OperadorRol", new[] { "Rol_Id" });
            DropIndex("dbo.OperadorRol", new[] { "Operador_Email" });
            DropIndex("dbo.Usuario", new[] { "Provincia_Id" });
            DropIndex("dbo.Usuario", new[] { "Localidad_Id" });
            DropIndex("dbo.Localidad", new[] { "Provincia_Id" });
            DropTable("dbo.OperadorRol");
            DropTable("dbo.Usuario");
            DropTable("dbo.Rol");
            DropTable("dbo.Provincia");
            DropTable("dbo.Localidad");
        }
    }
}