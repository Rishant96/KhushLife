namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eStoreInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        HasVariants = c.Boolean(nullable: false),
                        VendorId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturer", t => t.Manufacturer_Id)
                .ForeignKey("dbo.IdentityUser", t => t.Vendor_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsBase = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Attribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        Line3 = c.String(),
                        Zip = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderValue = c.Single(nullable: false),
                        DeliverBy = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StockedProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        VendorId = c.Int(nullable: false),
                        StockedInStoreId = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturer", t => t.Manufacturer_Id)
                .ForeignKey("dbo.IdentityUser", t => t.Vendor_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.StockedInStore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Stock = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockedProduct", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VendorId = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUser", t => t.Vendor_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUser");
            DropForeignKey("dbo.StockedProduct", "Vendor_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.StockedInStore", "StoreId", "dbo.Store");
            DropForeignKey("dbo.Store", "Vendor_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.Store", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.StockedInStore", "ProductId", "dbo.StockedProduct");
            DropForeignKey("dbo.StockedProduct", "Manufacturer_Id", "dbo.Manufacturer");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Order", "User_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.OrderItem", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CartItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "Vendor_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.Address", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.Product", "Manufacturer_Id", "dbo.Manufacturer");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Attribute", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.Store", new[] { "Vendor_Id" });
            DropIndex("dbo.Store", new[] { "Address_Id" });
            DropIndex("dbo.StockedInStore", new[] { "ProductId" });
            DropIndex("dbo.StockedInStore", new[] { "StoreId" });
            DropIndex("dbo.StockedProduct", new[] { "Vendor_Id" });
            DropIndex("dbo.StockedProduct", new[] { "Manufacturer_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderItem", new[] { "Order_Id" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.Order", new[] { "User_Id" });
            DropIndex("dbo.Address", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUser", "UserNameIndex");
            DropIndex("dbo.Attribute", new[] { "Category_Id" });
            DropIndex("dbo.Category", new[] { "Category_Id" });
            DropIndex("dbo.Product", new[] { "Vendor_Id" });
            DropIndex("dbo.Product", new[] { "Manufacturer_Id" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.CartItem", new[] { "ProductId" });
            DropIndex("dbo.CartItem", new[] { "CartId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Store");
            DropTable("dbo.StockedInStore");
            DropTable("dbo.StockedProduct");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
            DropTable("dbo.Address");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.IdentityUser");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Attribute");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.CartItem");
            DropTable("dbo.Cart");
        }
    }
}
