namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eStore_1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cart", newName: "Carts");
            RenameTable(name: "dbo.CartItem", newName: "CartItems");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Category", newName: "Categories");
            RenameTable(name: "dbo.Attribute", newName: "Attributes");
            RenameTable(name: "dbo.Manufacturer", newName: "Manufacturers");
            RenameTable(name: "dbo.IdentityUser", newName: "IdentityUsers");
            RenameTable(name: "dbo.Address", newName: "Addresses");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.OrderItem", newName: "OrderItems");
            RenameTable(name: "dbo.StockedProduct", newName: "StockedProducts");
            RenameTable(name: "dbo.StockedInStore", newName: "StockedInStores");
            RenameTable(name: "dbo.Store", newName: "Stores");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Stores", newName: "Store");
            RenameTable(name: "dbo.StockedInStores", newName: "StockedInStore");
            RenameTable(name: "dbo.StockedProducts", newName: "StockedProduct");
            RenameTable(name: "dbo.OrderItems", newName: "OrderItem");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Addresses", newName: "Address");
            RenameTable(name: "dbo.IdentityUsers", newName: "IdentityUser");
            RenameTable(name: "dbo.Manufacturers", newName: "Manufacturer");
            RenameTable(name: "dbo.Attributes", newName: "Attribute");
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.CartItems", newName: "CartItem");
            RenameTable(name: "dbo.Carts", newName: "Cart");
        }
    }
}
