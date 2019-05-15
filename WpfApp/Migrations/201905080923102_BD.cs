namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassCars",
                c => new
                    {
                        ClassCarId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClassCarId);
            
            CreateTable(
                "dbo.PromotionCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PromotionId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.PromotionId, cascadeDelete: true)
                .Index(t => t.PromotionId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionId);
            
            AddColumn("dbo.Cars", "ClassCarsId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "CountOfSeets", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "TransmissionsId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Conditioner", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "Petrol", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "ClassCar_ClassCarId", c => c.Int());
            AddColumn("dbo.Cars", "Transmission_TransmissionId", c => c.Int());
            CreateIndex("dbo.Cars", "ClassCar_ClassCarId");
            CreateIndex("dbo.Cars", "Transmission_TransmissionId");
            AddForeignKey("dbo.Cars", "ClassCar_ClassCarId", "dbo.ClassCars", "ClassCarId");
            AddForeignKey("dbo.Cars", "Transmission_TransmissionId", "dbo.Transmissions", "TransmissionId");
            DropColumn("dbo.Cars", "Class");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Class", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Cars", "Transmission_TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.PromotionCars", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.PromotionCars", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "ClassCar_ClassCarId", "dbo.ClassCars");
            DropIndex("dbo.PromotionCars", new[] { "CarId" });
            DropIndex("dbo.PromotionCars", new[] { "PromotionId" });
            DropIndex("dbo.Cars", new[] { "Transmission_TransmissionId" });
            DropIndex("dbo.Cars", new[] { "ClassCar_ClassCarId" });
            DropColumn("dbo.Cars", "Transmission_TransmissionId");
            DropColumn("dbo.Cars", "ClassCar_ClassCarId");
            DropColumn("dbo.Cars", "Petrol");
            DropColumn("dbo.Cars", "Conditioner");
            DropColumn("dbo.Cars", "TransmissionsId");
            DropColumn("dbo.Cars", "CountOfSeets");
            DropColumn("dbo.Cars", "ClassCarsId");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Promotions");
            DropTable("dbo.PromotionCars");
            DropTable("dbo.ClassCars");
        }
    }
}
