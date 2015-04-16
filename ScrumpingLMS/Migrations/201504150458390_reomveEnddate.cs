namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reomveEnddate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Klasses", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Klasses", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
