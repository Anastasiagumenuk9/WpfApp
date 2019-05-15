namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Locations", name: "City_Id", newName: "CityId");
            RenameIndex(table: "dbo.Locations", name: "IX_City_Id", newName: "IX_CityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Locations", name: "IX_CityId", newName: "IX_City_Id");
            RenameColumn(table: "dbo.Locations", name: "CityId", newName: "City_Id");
        }
    }
}
