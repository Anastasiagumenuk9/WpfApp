namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class L : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Countries", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cars", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Leases", "UserId", "dbo.Users");
            DropIndex("dbo.Cars", new[] { "CityId" });
            DropIndex("dbo.Cars", new[] { "Country_Id" });
            DropIndex("dbo.Countries", new[] { "City_Id" });
            DropIndex("dbo.Leases", new[] { "UserId" });
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Cars", "CityId");
            DropColumn("dbo.Cars", "Country_Id");
            DropColumn("dbo.Cities", "CountryId");
            DropColumn("dbo.Countries", "City_Id");
            DropColumn("dbo.Leases", "UserId");
            DropColumn("dbo.Leases", "CarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leases", "CarId", c => c.Int());
            AddColumn("dbo.Leases", "UserId", c => c.Int());
            AddColumn("dbo.Countries", "City_Id", c => c.Int());
            AddColumn("dbo.Cities", "CountryId", c => c.Int());
            AddColumn("dbo.Cars", "Country_Id", c => c.Int());
            AddColumn("dbo.Cars", "CityId", c => c.Int());
            DropTable("dbo.Locations");
            CreateIndex("dbo.Leases", "UserId");
            CreateIndex("dbo.Countries", "City_Id");
            CreateIndex("dbo.Cars", "Country_Id");
            CreateIndex("dbo.Cars", "CityId");
            AddForeignKey("dbo.Leases", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Cars", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Countries", "City_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Cars", "Country_Id", "dbo.Countries", "Id");
        }
    }
}
