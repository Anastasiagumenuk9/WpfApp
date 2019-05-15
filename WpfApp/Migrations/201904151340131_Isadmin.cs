namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Isadmin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "IsAdmin", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
        }
    }
}
