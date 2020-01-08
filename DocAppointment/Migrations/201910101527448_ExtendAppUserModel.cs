namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendAppUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "GenderId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsSecuredByNHIF", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", "GenderId");
            AddForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders");
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            DropColumn("dbo.AspNetUsers", "IsSecuredByNHIF");
            DropColumn("dbo.AspNetUsers", "Birthdate");
            DropColumn("dbo.AspNetUsers", "GenderId");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
