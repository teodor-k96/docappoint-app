namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSpecialtiesValues : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Общопрактикуващ лекар', 10.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Вътрешни болести', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Гастроентерология', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Кардиохирургия', 25.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Неврохирургия', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Очни болести', 30.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Общопрактикуващ лекар', 10.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Урология', 15.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Инфекциозни болести', 30.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Нефрология', 20.00)");
            Sql("insert into Specialties (SpecialtyName, PriceForExamination) values (N'Детски болести', 20.00)");

        }
        
        public override void Down()
        {
        }
    }
}
