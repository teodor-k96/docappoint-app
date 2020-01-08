namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorPhotoProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "UserPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "UserPhoto");
        }
    }
}
