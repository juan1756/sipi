namespace SIPI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orador_MediosAudiovisual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orador", "MedioAudiovisual_Id", "dbo.MedioAudiovisual");
            DropIndex("dbo.Orador", new[] { "MedioAudiovisual_Id" });
            CreateTable(
                "dbo.MedioAudiovisualOrador",
                c => new
                    {
                        MedioAudiovisual_Id = c.Int(nullable: false),
                        Orador_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedioAudiovisual_Id, t.Orador_Id })
                .ForeignKey("dbo.MedioAudiovisual", t => t.MedioAudiovisual_Id)
                .ForeignKey("dbo.Orador", t => t.Orador_Id)
                .Index(t => t.MedioAudiovisual_Id)
                .Index(t => t.Orador_Id);
            
            DropColumn("dbo.Orador", "MedioAudiovisual_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orador", "MedioAudiovisual_Id", c => c.Int());
            DropForeignKey("dbo.MedioAudiovisualOrador", "Orador_Id", "dbo.Orador");
            DropForeignKey("dbo.MedioAudiovisualOrador", "MedioAudiovisual_Id", "dbo.MedioAudiovisual");
            DropIndex("dbo.MedioAudiovisualOrador", new[] { "Orador_Id" });
            DropIndex("dbo.MedioAudiovisualOrador", new[] { "MedioAudiovisual_Id" });
            DropTable("dbo.MedioAudiovisualOrador");
            CreateIndex("dbo.Orador", "MedioAudiovisual_Id");
            AddForeignKey("dbo.Orador", "MedioAudiovisual_Id", "dbo.MedioAudiovisual", "Id");
        }
    }
}
