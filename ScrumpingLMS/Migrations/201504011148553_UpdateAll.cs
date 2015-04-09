namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseTasks", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Klasses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.PersonInformations", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.CourseTasks", new[] { "CourseId" });
            DropIndex("dbo.Klasses", new[] { "CourseId" });
            DropIndex("dbo.PersonInformations", new[] { "ApplicationUserId" });
            CreateTable(
                "dbo.ScheduleDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KlassId = c.Int(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Klasses", t => t.KlassId, cascadeDelete: true)
                .Index(t => t.KlassId);
            
            AddColumn("dbo.Klasses", "NumberOfDays", c => c.Int(nullable: false));
            DropColumn("dbo.Klasses", "CourseId");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseTasks");
            DropTable("dbo.PersonInformations");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfDays = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Klasses", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ScheduleDays", "KlassId", "dbo.Klasses");
            DropIndex("dbo.ScheduleDays", new[] { "KlassId" });
            DropColumn("dbo.Klasses", "NumberOfDays");
            DropTable("dbo.ScheduleDays");
            CreateIndex("dbo.PersonInformations", "ApplicationUserId");
            CreateIndex("dbo.Klasses", "CourseId");
            CreateIndex("dbo.CourseTasks", "CourseId");
            AddForeignKey("dbo.PersonInformations", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Klasses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseTasks", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
