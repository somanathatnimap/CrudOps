namespace Product_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category_name = c.String(nullable: false),
                        category_description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Product_name = c.String(nullable: false),
                        Product_price = c.Int(nullable: false),
                        Product_description = c.String(nullable: false),
                        categories_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.categories_id, cascadeDelete: true)
                .Index(t => t.categories_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "categories_id", "dbo.categories");
            DropIndex("dbo.Products", new[] { "categories_id" });
            DropTable("dbo.Products");
            DropTable("dbo.categories");
        }
    }
}
