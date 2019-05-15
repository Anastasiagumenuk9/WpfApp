namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class per : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "Percent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "Percent");
        }
    }
}
