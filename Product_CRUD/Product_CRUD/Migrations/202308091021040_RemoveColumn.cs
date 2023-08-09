namespace Product_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "categories_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "categories_id");
        }
    }
}
