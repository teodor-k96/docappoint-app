namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialtiesValues : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'��������������� �����', 10.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'�������� �������', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'�����������������', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'��������������', 25.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'�������������', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'���� �������', 30.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'��������������� �����', 10.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'��������', 15.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'����������� �������', 30.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'����������', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'������ �������', 20.00)");

        }
        
        public override void Down()
        {
        }
    }
}
