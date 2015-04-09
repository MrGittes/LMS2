namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KlassId = c.Int(nullable: false),
                        NumberOfDays = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Klasses", t => t.KlassId, cascadeDelete: true)
                .Index(t => t.KlassId);
            
            CreateTable(
                "dbo.Klasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Task = c.String(),
                        Day = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Dokuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.KlassApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        KlassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Klasses", t => t.KlassId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.KlassId);
            
            CreateTable(
                "dbo.PersonInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        currentDay = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonInformations", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.KlassApplicationUsers", "KlassId", "dbo.Klasses");
            DropForeignKey("dbo.KlassApplicationUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Dokuments", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseTasks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "KlassId", "dbo.Klasses");
            DropIndex("dbo.PersonInformations", new[] { "ApplicationUserId" });
            DropIndex("dbo.KlassApplicationUsers", new[] { "KlassId" });
            DropIndex("dbo.KlassApplicationUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Dokuments", new[] { "ApplicationUserId" });
            DropIndex("dbo.CourseTasks", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "KlassId" });
            DropTable("dbo.PersonInformations");
            DropTable("dbo.KlassApplicationUsers");
            DropTable("dbo.Dokuments");
            DropTable("dbo.CourseTasks");
            DropTable("dbo.Klasses");
            DropTable("dbo.Courses");
        }
    }
}
