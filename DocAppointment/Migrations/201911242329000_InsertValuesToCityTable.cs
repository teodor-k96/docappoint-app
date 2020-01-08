namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValuesToCityTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Cities (CityName) values (N'Благоевград')");
            Sql("insert into Cities (CityName) values (N'Бургас')");
            Sql("insert into Cities (CityName) values (N'Варна')");
            Sql("insert into Cities (CityName) values (N'Велико Търново	')");
            Sql("insert into Cities (CityName) values (N'Видин')");
            Sql("insert into Cities (CityName) values (N'Враца')");
            Sql("insert into Cities (CityName) values (N'Габрово')");
            Sql("insert into Cities (CityName) values (N'Добрич')");
            Sql("insert into Cities (CityName) values (N'Кърджали')");
            Sql("insert into Cities (CityName) values (N'Кюстендил')");
            Sql("insert into Cities (CityName) values (N'Ловеч')");
            Sql("insert into Cities (CityName) values (N'Монтана')");
            Sql("insert into Cities (CityName) values (N'Пазарджик')");
            Sql("insert into Cities (CityName) values (N'Перник')");
            Sql("insert into Cities (CityName) values (N'Плевен')");
            Sql("insert into Cities (CityName) values (N'Пловдив')");
            Sql("insert into Cities (CityName) values (N'Разград')");
            Sql("insert into Cities (CityName) values (N'Русе')");
            Sql("insert into Cities (CityName) values (N'Силистра')");
            Sql("insert into Cities (CityName) values (N'Сливен')");
            Sql("insert into Cities (CityName) values (N'Смолян')");
            Sql("insert into Cities (CityName) values (N'София')");
            Sql("insert into Cities (CityName) values (N'Стара Загора')");
            Sql("insert into Cities (CityName) values (N'Търговище')");
            Sql("insert into Cities (CityName) values (N'Хасково')");
            Sql("insert into Cities (CityName) values (N'Шумен')");
            Sql("insert into Cities (CityName) values (N'Ямбол')");
        }
        
        public override void Down()
        {
        }
    }
}
