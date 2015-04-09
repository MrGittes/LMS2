namespace ScrumpingLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DokumentObjekt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dokuments", "DokumentObjekt", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dokuments", "DokumentObjekt");
        }
    }
}
