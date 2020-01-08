namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePriceOfExam : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "PriceOfExamination");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "PriceOfExamination", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
