namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.UsersBooks", newName: "Orders");
        }
        
        public override void Down()
        {
            //RenameTable(name: "dbo.Orders", newName: "UsersBooks");
        }
    }
}
