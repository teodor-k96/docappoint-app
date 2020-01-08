namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialtiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecialtyName = c.String(),
                        PriceForExamination = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Specialties");
        }
    }
}
