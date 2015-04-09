namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DayNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleDays", "DayNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleDays", "DayNumber");
        }
    }
}
