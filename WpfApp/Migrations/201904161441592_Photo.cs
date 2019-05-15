namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Photo");
        }
    }
}
