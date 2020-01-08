namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCitiesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "CitiesId", "dbo.Cities");
            DropIndex("dbo.Doctors", new[] { "CitiesId" });
            DropColumn("dbo.Doctors", "CitiesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "CitiesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "CitiesId");
            AddForeignKey("dbo.Doctors", "CitiesId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
