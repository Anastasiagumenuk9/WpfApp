namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "City_Id", c => c.Int());
            AddColumn("dbo.Cities", "CountryId", c => c.Int());
            AddColumn("dbo.Locations", "City_Id", c => c.Int());
            CreateIndex("dbo.Cars", "City_Id");
            CreateIndex("dbo.Cities", "CountryId");
            CreateIndex("dbo.Locations", "City_Id");
            AddForeignKey("dbo.Cars", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id");
            AddForeignKey("dbo.Locations", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cars", "City_Id", "dbo.Cities");
            DropIndex("dbo.Locations", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Cars", new[] { "City_Id" });
            DropColumn("dbo.Locations", "City_Id");
            DropColumn("dbo.Cities", "CountryId");
            DropColumn("dbo.Cars", "City_Id");
        }
    }
}
