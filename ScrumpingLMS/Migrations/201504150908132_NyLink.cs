namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NyLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleDays", "LinkToDokument", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleDays", "LinkToDokument");
        }
    }
}
