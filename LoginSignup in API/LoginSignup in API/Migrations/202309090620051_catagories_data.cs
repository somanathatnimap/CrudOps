namespace LoginSignup_in_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catagories_data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        catagory_name = c.String(nullable: false),
                        catagory_desc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Catagories");
        }
    }
}
