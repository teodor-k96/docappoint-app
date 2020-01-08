namespace DocAppointment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCanManageDoctorsRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [GenderId], [Birthdate], [IsSecuredByNHIF], [UserPhoto]) VALUES (N'67687fc5-0850-4d5f-a4c8-aea6514fd598', N'teodorkostadinov6@gmail.com', 1, N'ANUu4F70oXD6kYOLExpvE3QvGneY04G8Zjz108j3rSlh+yTcG+Hk4j34HuK162U3sw==', N'2b31115c-b10f-4c2f-b5b3-1adc86c06a1d', NULL, 0, 0, NULL, 1, 0, N'teodorkostadinov6@gmail.com', N'Теодор Костадинов', 1, N'1996-06-10 00:00:00', 1, 0xFFD8FFE000104A46494600010100000100010000FFDB00430001010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101010101FFDB00430101010101010101010101010101010101010101010101010101010101010101010101)
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3b698421-b0cd-4a61-94fa-f58d456067e9', N'CanManageDoctors')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'67687fc5-0850-4d5f-a4c8-aea6514fd598', N'3b698421-b0cd-4a61-94fa-f58d456067e9')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
