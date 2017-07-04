namespace SIPI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario_RecuperoContrasena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "ContrasenaNueva", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Usuario", "Hash", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Hash");
            DropColumn("dbo.Usuario", "ContrasenaNueva");
        }
    }
}
