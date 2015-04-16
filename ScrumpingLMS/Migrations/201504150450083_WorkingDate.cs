namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkingDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleDays", "WorkingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleDays", "WorkingDate");
        }
    }
}
