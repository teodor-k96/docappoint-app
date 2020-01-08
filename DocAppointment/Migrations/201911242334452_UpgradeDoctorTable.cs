namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeDoctorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "CityId");
            AddForeignKey("dbo.Doctors", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "CityId", "dbo.Cities");
            DropIndex("dbo.Doctors", new[] { "CityId" });
            DropColumn("dbo.Doctors", "CityId");
        }
    }
}
