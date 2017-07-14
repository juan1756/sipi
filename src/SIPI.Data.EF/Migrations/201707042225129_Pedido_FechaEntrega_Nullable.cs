namespace SIPI.Data.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Pedido_FechaEntrega_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pedido", "FechaEntregado", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("dbo.Pedido", "FechaEntregado", c => c.DateTime(nullable: false));
        }
    }
}