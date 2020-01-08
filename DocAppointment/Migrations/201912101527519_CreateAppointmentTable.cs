namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAppointmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        DateOfAppointment = c.DateTime(nullable: false),
                        PriceOfExamination = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_Id = c.String(nullable: false, maxLength: 128),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "Doctor_Id" });
            DropIndex("dbo.Appointments", new[] { "Client_Id" });
            DropTable("dbo.Appointments");
        }
    }
}
