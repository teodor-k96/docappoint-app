namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        AddressLine = c.String(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                        WorksWithNHIF = c.Boolean(nullable: false),
                        DoctorInfo = c.String(),
                        WorktimeStart = c.DateTime(nullable: false),
                        WorktimeEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .Index(t => t.SpecialtyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecialtyId", "dbo.Specialties");
            DropIndex("dbo.Doctors", new[] { "SpecialtyId" });
            DropTable("dbo.Doctors");
        }
    }
}
