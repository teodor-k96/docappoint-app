namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceForExamination : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "PriceForExamination", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Specialties", "PriceForExamination");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialties", "PriceForExamination", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Doctors", "PriceForExamination");
        }
    }
}
