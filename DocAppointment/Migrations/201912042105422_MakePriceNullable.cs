namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePriceNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "PriceForExamination", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "PriceForExamination", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
