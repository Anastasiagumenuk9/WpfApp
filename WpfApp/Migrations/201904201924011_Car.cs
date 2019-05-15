namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "Price", c => c.Int());
        }
    }
}
