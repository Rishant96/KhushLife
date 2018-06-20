namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryEdit1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Categories", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Categories", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Categories", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Categories", name: "CategoryId", newName: "Category_Id");
        }
    }
}
