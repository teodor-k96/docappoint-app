namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGendersValues : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genders (GenderName) values (N'Мъж')");
            Sql("insert into Genders (GenderName) values (N'Жена')");
        }
        
        public override void Down()
        {
        }
    }
}
