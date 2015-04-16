namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DokLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dokuments", "DokumentLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dokuments", "DokumentLink");
        }
    }
}
