namespace Authentication_using_forms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Credintials", "name", c => c.String());
            AlterColumn("dbo.Credintials", "email", c => c.String());
            AlterColumn("dbo.Credintials", "password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Credintials", "password", c => c.Int(nullable: false));
            AlterColumn("dbo.Credintials", "email", c => c.Int(nullable: false));
            AlterColumn("dbo.Credintials", "name", c => c.Int(nullable: false));
        }
    }
}
