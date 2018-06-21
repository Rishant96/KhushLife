namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedProducts1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specifications", "BaseCost", c => c.Single(nullable: false));
            AddColumn("dbo.SpecOptions", "SpecCost", c => c.Single(nullable: false));
            AddColumn("dbo.StockedProducts", "BasePrice", c => c.Single(nullable: false));
            AddColumn("dbo.StockedProducts", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.finalSpecs", "Stock", c => c.Int(nullable: false));
            CreateIndex("dbo.StockedProducts", "ProductId");
            AddForeignKey("dbo.StockedProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.StockedProducts", "Name");
            DropColumn("dbo.StockedProducts", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockedProducts", "Manufacturer_Id", c => c.Int());
            AddColumn("dbo.StockedProducts", "Description", c => c.String());
            AddColumn("dbo.StockedProducts", "Name", c => c.String());
            DropForeignKey("dbo.StockedProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.StockedProducts", new[] { "ProductId" });
            DropColumn("dbo.finalSpecs", "Stock");
            DropColumn("dbo.StockedProducts", "ProductId");
            DropColumn("dbo.StockedProducts", "BasePrice");
            DropColumn("dbo.SpecOptions", "SpecCost");
            DropColumn("dbo.Specifications", "BaseCost");
            CreateIndex("dbo.StockedProducts", "Manufacturer_Id");
            AddForeignKey("dbo.StockedProducts", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
    }
}
