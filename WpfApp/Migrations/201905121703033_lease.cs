namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lease : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leases", "CarName", c => c.String());
            AddColumn("dbo.Leases", "DateStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leases", "DateEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Leases", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leases", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Leases", "DateEnd");
            DropColumn("dbo.Leases", "DateStart");
            DropColumn("dbo.Leases", "CarName");
        }
    }
}
