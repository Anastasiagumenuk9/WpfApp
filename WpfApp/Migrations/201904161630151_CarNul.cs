namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarNul : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Price", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Price", c => c.Int(nullable: false));
        }
    }
}
