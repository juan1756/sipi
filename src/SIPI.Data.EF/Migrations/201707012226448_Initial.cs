namespace SIPI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100, unicode: false),
                        Provincia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_Id)
                .Index(t => t.Provincia_Id);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Nombre = c.String(maxLength: 100, unicode: false),
                        Apellido = c.String(maxLength: 100, unicode: false),
                        Contrasena = c.String(maxLength: 100, unicode: false),
                        Altura = c.Int(),
                        Calle = c.String(maxLength: 100, unicode: false),
                        Direccion = c.String(maxLength: 100, unicode: false),
                        Telefono = c.String(maxLength: 100, unicode: false),
                        Piso = c.String(maxLength: 100, unicode: false),
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
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100, unicode: false),
                        Descripcion = c.String(maxLength: 100, unicode: false),
                        Operador_Email = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Operador_Email)
                .Index(t => t.Operador_Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rol", "Operador_Email", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Provincia_Id", "dbo.Provincia");
            DropForeignKey("dbo.Usuario", "Localidad_Id", "dbo.Localidad");
            DropForeignKey("dbo.Localidad", "Provincia_Id", "dbo.Provincia");
            DropIndex("dbo.Rol", new[] { "Operador_Email" });
            DropIndex("dbo.Usuario", new[] { "Provincia_Id" });
            DropIndex("dbo.Usuario", new[] { "Localidad_Id" });
            DropIndex("dbo.Localidad", new[] { "Provincia_Id" });
            DropTable("dbo.Rol");
            DropTable("dbo.Usuario");
            DropTable("dbo.Provincia");
            DropTable("dbo.Localidad");
        }
    }
}
