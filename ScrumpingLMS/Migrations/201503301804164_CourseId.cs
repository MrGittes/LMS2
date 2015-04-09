namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "KlassId", "dbo.Klasses");
            DropIndex("dbo.Courses", new[] { "KlassId" });
            AddColumn("dbo.Klasses", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Klasses", "CourseId");
            AddForeignKey("dbo.Klasses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "KlassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "KlassId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Klasses", "CourseId", "dbo.Courses");
            DropIndex("dbo.Klasses", new[] { "CourseId" });
            DropColumn("dbo.Klasses", "CourseId");
            CreateIndex("dbo.Courses", "KlassId");
            AddForeignKey("dbo.Courses", "KlassId", "dbo.Klasses", "Id", cascadeDelete: true);
        }
    }
}
