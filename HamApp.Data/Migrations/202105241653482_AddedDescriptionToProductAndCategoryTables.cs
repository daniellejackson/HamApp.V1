namespace HamApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionToProductAndCategoryTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Categories", "Description");
        }
    }
}
