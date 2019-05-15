namespace WpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ke : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "ClassCar_ClassCarId", "dbo.ClassCars");
            DropForeignKey("dbo.Cars", "Transmission_TransmissionId", "dbo.Transmissions");
            DropIndex("dbo.Cars", new[] { "ClassCar_ClassCarId" });
            DropIndex("dbo.Cars", new[] { "Transmission_TransmissionId" });
            RenameColumn(table: "dbo.Cars", name: "ClassCar_ClassCarId", newName: "ClassCarId");
            RenameColumn(table: "dbo.Cars", name: "Transmission_TransmissionId", newName: "TransmissionId");
            AlterColumn("dbo.Cars", "ClassCarId", c => c.Int(nullable: true));
            AlterColumn("dbo.Cars", "TransmissionId", c => c.Int(nullable: true));
            CreateIndex("dbo.Cars", "ClassCarId");
            CreateIndex("dbo.Cars", "TransmissionId");
            AddForeignKey("dbo.Cars", "ClassCarId", "dbo.ClassCars", "ClassCarId", cascadeDelete: true);
            AddForeignKey("dbo.Cars", "TransmissionId", "dbo.Transmissions", "TransmissionId", cascadeDelete: true);
            DropColumn("dbo.Cars", "ClassCarsId");
            DropColumn("dbo.Cars", "TransmissionsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "TransmissionsId", c => c.Int(nullable: true));
            AddColumn("dbo.Cars", "ClassCarsId", c => c.Int(nullable: true));
            DropForeignKey("dbo.Cars", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Cars", "ClassCarId", "dbo.ClassCars");
            DropIndex("dbo.Cars", new[] { "TransmissionId" });
            DropIndex("dbo.Cars", new[] { "ClassCarId" });
            AlterColumn("dbo.Cars", "TransmissionId", c => c.Int());
            AlterColumn("dbo.Cars", "ClassCarId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "TransmissionId", newName: "Transmission_TransmissionId");
            RenameColumn(table: "dbo.Cars", name: "ClassCarId", newName: "ClassCar_ClassCarId");
            CreateIndex("dbo.Cars", "Transmission_TransmissionId");
            CreateIndex("dbo.Cars", "ClassCar_ClassCarId");
            AddForeignKey("dbo.Cars", "Transmission_TransmissionId", "dbo.Transmissions", "TransmissionId");
            AddForeignKey("dbo.Cars", "ClassCar_ClassCarId", "dbo.ClassCars", "ClassCarId");
        }
    }
}
