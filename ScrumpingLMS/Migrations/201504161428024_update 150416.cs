namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update150416 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScheduleDayUploads", "KlassId", "dbo.Klasses");
            DropIndex("dbo.ScheduleDayUploads", new[] { "KlassId" });
            DropColumn("dbo.Dokuments", "DokumentLink");
            DropTable("dbo.ScheduleDayUploads");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ScheduleDayUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayNumber = c.Int(nullable: false),
                        KlassId = c.Int(nullable: false),
                        LinkToDokument = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Dokuments", "DokumentLink", c => c.String());
            CreateIndex("dbo.ScheduleDayUploads", "KlassId");
            AddForeignKey("dbo.ScheduleDayUploads", "KlassId", "dbo.Klasses", "Id", cascadeDelete: true);
        }
    }
}
