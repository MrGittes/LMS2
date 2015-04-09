namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShared : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SharedFolders", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SharedFolders", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.DokumentScheduleDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DokumentId = c.Int(nullable: false),
                        ScheduleDayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dokuments", t => t.DokumentId, cascadeDelete: true)
                .ForeignKey("dbo.ScheduleDays", t => t.ScheduleDayId, cascadeDelete: true)
                .Index(t => t.DokumentId)
                .Index(t => t.ScheduleDayId);
            
            CreateTable(
                "dbo.SharedFolderApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SharedFolderId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.SharedFolders", t => t.SharedFolderId, cascadeDelete: true)
                .Index(t => t.SharedFolderId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CurrentDay", c => c.Int(nullable: false));
            AddColumn("dbo.SharedFolders", "Name", c => c.String());
            DropColumn("dbo.SharedFolders", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SharedFolders", "ApplicationUserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.SharedFolderApplicationUsers", "SharedFolderId", "dbo.SharedFolders");
            DropForeignKey("dbo.SharedFolderApplicationUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DokumentScheduleDays", "ScheduleDayId", "dbo.ScheduleDays");
            DropForeignKey("dbo.DokumentScheduleDays", "DokumentId", "dbo.Dokuments");
            DropIndex("dbo.SharedFolderApplicationUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.SharedFolderApplicationUsers", new[] { "SharedFolderId" });
            DropIndex("dbo.DokumentScheduleDays", new[] { "ScheduleDayId" });
            DropIndex("dbo.DokumentScheduleDays", new[] { "DokumentId" });
            DropColumn("dbo.SharedFolders", "Name");
            DropColumn("dbo.AspNetUsers", "CurrentDay");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.SharedFolderApplicationUsers");
            DropTable("dbo.DokumentScheduleDays");
            CreateIndex("dbo.SharedFolders", "ApplicationUserId");
            AddForeignKey("dbo.SharedFolders", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
