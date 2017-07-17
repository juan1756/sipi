namespace SIPI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Miembro_Remove_Direccion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "Direccion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "Direccion", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
