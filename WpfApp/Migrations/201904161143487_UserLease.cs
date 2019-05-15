namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLease : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leases", "UserId", c => c.Int());
            CreateIndex("dbo.Leases", "UserId");
            AddForeignKey("dbo.Leases", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leases", "UserId", "dbo.Users");
            DropIndex("dbo.Leases", new[] { "UserId" });
            DropColumn("dbo.Leases", "UserId");
        }
    }
}
