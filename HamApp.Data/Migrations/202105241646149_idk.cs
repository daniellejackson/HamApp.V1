namespace HamApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CategoryName", c => c.String());
            DropColumn("dbo.Customers", "Name");
        }
    }
}
