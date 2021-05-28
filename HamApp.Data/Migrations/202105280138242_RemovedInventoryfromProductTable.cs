namespace HamApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedInventoryfromProductTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "InventoryID", "dbo.Inventories");
            DropIndex("dbo.Products", new[] { "InventoryID" });
            DropColumn("dbo.Products", "InventoryID");
            DropTable("dbo.Inventories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "InventoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "InventoryID");
            AddForeignKey("dbo.Products", "InventoryID", "dbo.Inventories", "Id", cascadeDelete: true);
        }
    }
}
