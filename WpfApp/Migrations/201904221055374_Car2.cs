namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "CityId", newName: "City_Id");
            RenameIndex(table: "dbo.Cars", name: "IX_CityId", newName: "IX_City_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cars", name: "IX_City_Id", newName: "IX_CityId");
            RenameColumn(table: "dbo.Cars", name: "City_Id", newName: "CityId");
        }
    }
}
