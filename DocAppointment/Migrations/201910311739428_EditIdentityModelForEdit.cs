namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditIdentityModelForEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders");
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "GenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.AspNetUsers", "GenderId");
            AddForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders");
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            AlterColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "GenderId", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "FullName", c => c.String());
            CreateIndex("dbo.AspNetUsers", "GenderId");
            AddForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders", "Id");
        }
    }
}
