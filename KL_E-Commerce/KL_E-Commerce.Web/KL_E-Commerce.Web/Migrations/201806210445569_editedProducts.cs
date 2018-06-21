namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsVariable = c.Boolean(nullable: false),
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
                        IsSelected = c.Boolean(nullable: false),
                        IsPreSelected = c.Boolean(nullable: false),
                        HasConstraints = c.Boolean(nullable: false),
                        SpecificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specifications", t => t.SpecificationId, cascadeDelete: true)
                .Index(t => t.SpecificationId);
            
            CreateTable(
                "dbo.finalSpecs",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.finalSpecs", "StockedProductId", "dbo.StockedProducts");
            DropForeignKey("dbo.finalSpecs", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.SpecOptions", "SpecificationId", "dbo.Specifications");
            DropForeignKey("dbo.Specifications", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Specifications", "AttributeId", "dbo.Attributes");
            DropIndex("dbo.finalSpecs", new[] { "StockedProductId" });
            DropIndex("dbo.finalSpecs", new[] { "AttributeId" });
            DropIndex("dbo.SpecOptions", new[] { "SpecificationId" });
            DropIndex("dbo.Specifications", new[] { "ProductId" });
            DropIndex("dbo.Specifications", new[] { "AttributeId" });
            DropTable("dbo.finalSpecs");
            DropTable("dbo.SpecOptions");
            DropTable("dbo.Specifications");
        }
    }
}
