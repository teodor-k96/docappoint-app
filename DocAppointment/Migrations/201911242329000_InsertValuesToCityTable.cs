namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValuesToCityTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Cities (CityName) values (N'�����������')");
            Sql("insert into Cities (CityName) values (N'������')");
            Sql("insert into Cities (CityName) values (N'�����')");
            Sql("insert into Cities (CityName) values (N'������ �������	')");
            Sql("insert into Cities (CityName) values (N'�����')");
            Sql("insert into Cities (CityName) values (N'�����')");
            Sql("insert into Cities (CityName) values (N'�������')");
            Sql("insert into Cities (CityName) values (N'������')");
            Sql("insert into Cities (CityName) values (N'��������')");
            Sql("insert into Cities (CityName) values (N'���������')");
            Sql("insert into Cities (CityName) values (N'�����')");
            Sql("insert into Cities (CityName) values (N'�������')");
            Sql("insert into Cities (CityName) values (N'���������')");
            Sql("insert into Cities (CityName) values (N'������')");
            Sql("insert into Cities (CityName) values (N'������')");
            Sql("insert into Cities (CityName) values (N'�������')");
            Sql("insert into Cities (CityName) values (N'�������')");
            Sql("insert into Cities (CityName) values (N'����')");
            Sql("insert into Cities (CityName) values (N'��������')");
            Sql("insert into Cities (CityName) values (N'������')");
            Sql("insert into Cities (CityName) values (N'������')");
            Sql("insert into Cities (CityName) values (N'�����')");
            Sql("insert into Cities (CityName) values (N'����� ������')");
            Sql("insert into Cities (CityName) values (N'���������')");
            Sql("insert into Cities (CityName) values (N'�������')");
            Sql("insert into Cities (CityName) values (N'�����')");
            Sql("insert into Cities (CityName) values (N'�����')");
        }
        
        public override void Down()
        {
        }
    }
}
