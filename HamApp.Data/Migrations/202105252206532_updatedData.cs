namespace HamApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropTable("dbo.Transactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Transactions", "ProductId");
            CreateIndex("dbo.Transactions", "CustomerId");
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
