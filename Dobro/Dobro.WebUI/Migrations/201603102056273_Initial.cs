namespace Dobro.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doings", "Name", c => c.String());
            AlterColumn("dbo.Doings", "Description", c => c.String());
            AlterColumn("dbo.Doings", "Metro", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doings", "Metro", c => c.String(nullable: false));
            AlterColumn("dbo.Doings", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Doings", "Name", c => c.String(nullable: false));
        }
    }
}
