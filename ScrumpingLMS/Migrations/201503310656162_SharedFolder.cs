namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SharedFolder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SharedFolders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        SharedFolderObjekt = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SharedFolders", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SharedFolders", new[] { "ApplicationUserId" });
            DropTable("dbo.SharedFolders");
        }
    }
}
