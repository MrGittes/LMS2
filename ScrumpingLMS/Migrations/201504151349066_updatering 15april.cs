namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatering15april : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleDays", "WorkingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SharedFolders", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.SharedFolders", "LinkToDokument", c => c.String());
            CreateIndex("dbo.SharedFolders", "ApplicationUserId");
            AddForeignKey("dbo.SharedFolders", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Klasses", "EndDate");
            DropColumn("dbo.SharedFolders", "SharedFolderObjekt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SharedFolders", "SharedFolderObjekt", c => c.Binary());
            AddColumn("dbo.Klasses", "EndDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.SharedFolders", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SharedFolders", new[] { "ApplicationUserId" });
            DropColumn("dbo.SharedFolders", "LinkToDokument");
            DropColumn("dbo.SharedFolders", "ApplicationUserId");
            DropColumn("dbo.ScheduleDays", "WorkingDate");
        }
    }
}
