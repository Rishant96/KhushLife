namespace KL_E_Commerce.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String());
            AlterColumn("dbo.Attributes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attributes", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "Description");
        }
    }
}
