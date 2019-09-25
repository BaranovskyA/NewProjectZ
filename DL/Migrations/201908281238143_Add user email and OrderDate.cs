namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    public partial class AdduseremailandOrderDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DateOrder", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Orders", "DateOrder");
        }
    }
}
