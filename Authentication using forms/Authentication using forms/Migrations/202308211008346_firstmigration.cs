namespace Authentication_using_forms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credintials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.Int(nullable: false),
                        email = c.Int(nullable: false),
                        password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Credintials");
        }
    }
}
