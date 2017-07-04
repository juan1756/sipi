namespace SIPI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario_RecuperoContrasena2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "ContrasenaNueva");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "ContrasenaNueva", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
