namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGendersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {  
            DropTable("dbo.Genders");
        }
    }
}
