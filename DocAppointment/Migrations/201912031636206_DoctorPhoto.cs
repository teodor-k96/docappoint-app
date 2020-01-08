namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DoctorPhoto", c => c.Binary());
            DropColumn("dbo.Doctors", "UserPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "UserPhoto", c => c.Binary());
            DropColumn("dbo.Doctors", "DoctorPhoto");
        }
    }
}
