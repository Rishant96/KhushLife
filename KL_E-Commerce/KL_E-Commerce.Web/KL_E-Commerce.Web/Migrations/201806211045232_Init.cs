namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartItems",
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
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Manufacturer = c.String(),
                        Description = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        HasVariants = c.Boolean(nullable: false),
                        VendorId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.Vendor_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        IsBase = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Specifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsVariable = c.Boolean(nullable: false),
                        BaseCost = c.Single(nullable: false),
                        AttributeId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attributes", t => t.AttributeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.AttributeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.SpecOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        SpecCost = c.Single(nullable: false),
                        IsSelected = c.Boolean(nullable: false),
                        IsPreSelected = c.Boolean(nullable: false),
                        HasConstraints = c.Boolean(nullable: false),
                        SpecificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId, cascadeDelete: true)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.IdentityUsers",
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
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
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
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
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
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Addresses",
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
                "dbo.Orders",
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
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
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
                "dbo.StockedInStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Stock = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        StockedProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockedProducts", t => t.StockedProductId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.StockedProductId);
            
            CreateTable(
                "dbo.StockedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.Vendor_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.FinalSpecs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        AttributeId = c.Int(nullable: false),
                        StockedProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attributes", t => t.AttributeId, cascadeDelete: true)
                .ForeignKey("dbo.StockedProducts", t => t.StockedProductId, cascadeDelete: true)
                .Index(t => t.AttributeId)
                .Index(t => t.StockedProductId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VendorId = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                        Vendor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.Vendor_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.StockedInStores", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Stores", "Vendor_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Stores", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.StockedProducts", "Vendor_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.StockedInStores", "StockedProductId", "dbo.StockedProducts");
            DropForeignKey("dbo.FinalSpecs", "StockedProductId", "dbo.StockedProducts");
            DropForeignKey("dbo.FinalSpecs", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.StockedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Vendor_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Addresses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.SpecOptions", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.Specifications", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Specifications", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Attributes", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.Stores", new[] { "Vendor_Id" });
            DropIndex("dbo.Stores", new[] { "Address_Id" });
            DropIndex("dbo.FinalSpecs", new[] { "StockedProductId" });
            DropIndex("dbo.FinalSpecs", new[] { "AttributeId" });
            DropIndex("dbo.StockedProducts", new[] { "Vendor_Id" });
            DropIndex("dbo.StockedProducts", new[] { "ProductId" });
            DropIndex("dbo.StockedInStores", new[] { "StockedProductId" });
            DropIndex("dbo.StockedInStores", new[] { "StoreId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Addresses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            DropIndex("dbo.SpecOptions", new[] { "SpecificationId" });
            DropIndex("dbo.Specifications", new[] { "ProductId" });
            DropIndex("dbo.Specifications", new[] { "AttributeId" });
            DropIndex("dbo.Attributes", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "Vendor_Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Stores");
            DropTable("dbo.FinalSpecs");
            DropTable("dbo.StockedProducts");
            DropTable("dbo.StockedInStores");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Addresses");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.SpecOptions");
            DropTable("dbo.Specifications");
            DropTable("dbo.Attributes");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.CartItems");
            DropTable("dbo.Carts");
        }
    }
}
