namespace Product_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
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
                        id = c.Int(nullable: false),
                        Product_name = c.String(nullable: false),
                        Product_price = c.Int(nullable: false),
                        Product_description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.id)
                .Index(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "id", "dbo.categories");
            DropIndex("dbo.Products", new[] { "id" });
            DropTable("dbo.Products");
            DropTable("dbo.categories");
        }
    }
}
