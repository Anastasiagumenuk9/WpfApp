namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "City_Id", "dbo.Cities");
            DropIndex("dbo.Cars", new[] { "City_Id" });
            DropColumn("dbo.Cars", "City_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "City_Id", c => c.Int());
            CreateIndex("dbo.Cars", "City_Id");
            AddForeignKey("dbo.Cars", "City_Id", "dbo.Cities", "Id");
        }
    }
}
