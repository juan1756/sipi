namespace SIPI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nombre = c.String(maxLength: 150, unicode: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Operador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Operador_Id)
                .Index(t => t.Operador_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 150, unicode: false),
                        Nombre = c.String(nullable: false, maxLength: 150, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 150, unicode: false),
                        Contrasena = c.String(nullable: false, maxLength: 150, unicode: false),
                        ContrasenaNueva = c.String(maxLength: 150, unicode: false),
                        Hash = c.String(maxLength: 150, unicode: false),
                        Altura = c.Int(),
                        Calle = c.String(maxLength: 150, unicode: false),
                        Direccion = c.String(maxLength: 150, unicode: false),
                        Telefono = c.String(maxLength: 150, unicode: false),
                        Piso = c.String(maxLength: 150, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Localidad_Id = c.Int(),
                        Provincia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.Localidad_Id)
                .ForeignKey("dbo.Provincia", t => t.Provincia_Id)
                .Index(t => t.Localidad_Id)
                .Index(t => t.Provincia_Id);
            
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
                "dbo.MedioAudiovisual",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaGrabacion = c.DateTime(nullable: false),
                        Tema = c.String(maxLength: 150, unicode: false),
                        Url = c.String(nullable: false, maxLength: 5000, unicode: false),
                        Tamano = c.Int(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                        Tipo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id)
                .ForeignKey("dbo.Tipo", t => t.Tipo_Id)
                .Index(t => t.Categoria_Id)
                .Index(t => t.Tipo_Id);
            
            CreateTable(
                "dbo.Orador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150, unicode: false),
                        Apellido = c.String(maxLength: 150, unicode: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Operador_Id = c.Int(),
                        MedioAudiovisual_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Operador_Id)
                .ForeignKey("dbo.MedioAudiovisual", t => t.MedioAudiovisual_Id)
                .Index(t => t.Operador_Id)
                .Index(t => t.MedioAudiovisual_Id);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Numero = c.Int(nullable: false, identity: true),
                        CantidadPedido = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaEntregado = c.DateTime(nullable: false),
                        Miembro_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Numero)
                .ForeignKey("dbo.Usuario", t => t.Miembro_Id)
                .Index(t => t.Miembro_Id);
            
            CreateTable(
                "dbo.Insumo",
                c => new
                    {
                        PedidoNumero = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tamano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PedidoNumero, t.Numero })
                .ForeignKey("dbo.Pedido", t => t.PedidoNumero)
                .Index(t => t.PedidoNumero);
            
            CreateTable(
                "dbo.OperadorRol",
                c => new
                    {
                        Operador_Id = c.Int(nullable: false),
                        Rol_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Operador_Id, t.Rol_Id })
                .ForeignKey("dbo.Usuario", t => t.Operador_Id)
                .ForeignKey("dbo.Rol", t => t.Rol_Id)
                .Index(t => t.Operador_Id)
                .Index(t => t.Rol_Id);
            
            CreateTable(
                "dbo.InsumoMedioAudiovisual",
                c => new
                    {
                        Insumo_PedidoNumero = c.Int(nullable: false),
                        Insumo_Numero = c.Int(nullable: false),
                        MedioAudiovisual_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Insumo_PedidoNumero, t.Insumo_Numero, t.MedioAudiovisual_Id })
                .ForeignKey("dbo.Insumo", t => new { t.Insumo_PedidoNumero, t.Insumo_Numero })
                .ForeignKey("dbo.MedioAudiovisual", t => t.MedioAudiovisual_Id)
                .Index(t => new { t.Insumo_PedidoNumero, t.Insumo_Numero })
                .Index(t => t.MedioAudiovisual_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "Miembro_Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Provincia_Id", "dbo.Provincia");
            DropForeignKey("dbo.Usuario", "Localidad_Id", "dbo.Localidad");
            DropForeignKey("dbo.Insumo", "PedidoNumero", "dbo.Pedido");
            DropForeignKey("dbo.InsumoMedioAudiovisual", "MedioAudiovisual_Id", "dbo.MedioAudiovisual");
            DropForeignKey("dbo.InsumoMedioAudiovisual", new[] { "Insumo_PedidoNumero", "Insumo_Numero" }, "dbo.Insumo");
            DropForeignKey("dbo.MedioAudiovisual", "Tipo_Id", "dbo.Tipo");
            DropForeignKey("dbo.Orador", "MedioAudiovisual_Id", "dbo.MedioAudiovisual");
            DropForeignKey("dbo.Orador", "Operador_Id", "dbo.Usuario");
            DropForeignKey("dbo.MedioAudiovisual", "Categoria_Id", "dbo.Categoria");
            DropForeignKey("dbo.Localidad", "Provincia_Id", "dbo.Provincia");
            DropForeignKey("dbo.Categoria", "Operador_Id", "dbo.Usuario");
            DropForeignKey("dbo.OperadorRol", "Rol_Id", "dbo.Rol");
            DropForeignKey("dbo.OperadorRol", "Operador_Id", "dbo.Usuario");
            DropIndex("dbo.InsumoMedioAudiovisual", new[] { "MedioAudiovisual_Id" });
            DropIndex("dbo.InsumoMedioAudiovisual", new[] { "Insumo_PedidoNumero", "Insumo_Numero" });
            DropIndex("dbo.OperadorRol", new[] { "Rol_Id" });
            DropIndex("dbo.OperadorRol", new[] { "Operador_Id" });
            DropIndex("dbo.Insumo", new[] { "PedidoNumero" });
            DropIndex("dbo.Pedido", new[] { "Miembro_Id" });
            DropIndex("dbo.Orador", new[] { "MedioAudiovisual_Id" });
            DropIndex("dbo.Orador", new[] { "Operador_Id" });
            DropIndex("dbo.MedioAudiovisual", new[] { "Tipo_Id" });
            DropIndex("dbo.MedioAudiovisual", new[] { "Categoria_Id" });
            DropIndex("dbo.Localidad", new[] { "Provincia_Id" });
            DropIndex("dbo.Usuario", new[] { "Provincia_Id" });
            DropIndex("dbo.Usuario", new[] { "Localidad_Id" });
            DropIndex("dbo.Categoria", new[] { "Operador_Id" });
            DropTable("dbo.InsumoMedioAudiovisual");
            DropTable("dbo.OperadorRol");
            DropTable("dbo.Insumo");
            DropTable("dbo.Pedido");
            DropTable("dbo.Tipo");
            DropTable("dbo.Orador");
            DropTable("dbo.MedioAudiovisual");
            DropTable("dbo.Provincia");
            DropTable("dbo.Localidad");
            DropTable("dbo.Rol");
            DropTable("dbo.Usuario");
            DropTable("dbo.Categoria");
        }
    }
}
