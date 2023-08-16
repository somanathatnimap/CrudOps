namespace Product_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.categories", "catergory_status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.categories", "catergory_status");
        }
    }
}
