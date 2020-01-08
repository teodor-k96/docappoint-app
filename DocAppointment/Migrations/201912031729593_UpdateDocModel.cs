namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "FullName", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Doctors", "AddressLine", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Doctors", "DoctorInfo", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "DoctorInfo", c => c.String());
            AlterColumn("dbo.Doctors", "AddressLine", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "FullName", c => c.String(nullable: false));
        }
    }
}
