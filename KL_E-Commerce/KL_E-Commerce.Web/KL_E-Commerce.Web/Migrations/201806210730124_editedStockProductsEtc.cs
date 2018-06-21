namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedStockProductsEtc : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StockedInStores", name: "ProductId", newName: "StockedProductId");
            RenameIndex(table: "dbo.StockedInStores", name: "IX_ProductId", newName: "IX_StockedProductId");
            DropColumn("dbo.StockedProducts", "BasePrice");
            DropColumn("dbo.StockedProducts", "StockedInStoreId");
            DropColumn("dbo.FinalSpecs", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FinalSpecs", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.StockedProducts", "StockedInStoreId", c => c.Int(nullable: false));
            AddColumn("dbo.StockedProducts", "BasePrice", c => c.Single(nullable: false));
            RenameIndex(table: "dbo.StockedInStores", name: "IX_StockedProductId", newName: "IX_ProductId");
            RenameColumn(table: "dbo.StockedInStores", name: "StockedProductId", newName: "ProductId");
        }
    }
}
