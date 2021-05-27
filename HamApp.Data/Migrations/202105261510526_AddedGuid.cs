namespace HamApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Products", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Inventories", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customers", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OwnerId");
            DropColumn("dbo.Inventories", "OwnerId");
            DropColumn("dbo.Products", "OwnerId");
            DropColumn("dbo.Categories", "OwnerId");
        }
    }
}
