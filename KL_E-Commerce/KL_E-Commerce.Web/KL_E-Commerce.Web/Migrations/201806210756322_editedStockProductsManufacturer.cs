namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedStockProductsManufacturer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockedProducts", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.StockedProducts", new[] { "ManufacturerId" });
            DropColumn("dbo.StockedProducts", "ManufacturerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockedProducts", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.StockedProducts", "ManufacturerId");
            AddForeignKey("dbo.StockedProducts", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
    }
}
