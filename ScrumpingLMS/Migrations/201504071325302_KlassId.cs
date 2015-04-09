namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KlassId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "KlassId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "KlassId");
        }
    }
}
