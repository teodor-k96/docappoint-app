namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGendersValues : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genders (GenderName) values (N'���')");
            Sql("insert into Genders (GenderName) values (N'����')");
        }
        
        public override void Down()
        {
        }
    }
}
