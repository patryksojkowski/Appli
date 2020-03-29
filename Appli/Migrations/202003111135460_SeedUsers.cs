namespace Appli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a1b6420c-5dbc-4e50-9989-d123c9d0200e', N'admin@vidly.com', 0, N'AKfwn70z1YmSKty74RwcLYqCKndpMESjbDh0Bh/IkgbufrGaZieG/E6YvW1AFheWRg==', N'bc820873-9420-47aa-9726-2eff39387403', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bad136f3-841a-44ab-a3c0-8075502f20f1', N'guest@vidly.com', 0, N'AMrlrej3ryaqW0B8yqEUHzT6doFB8NKA/XJ/h5nqRw/RVaXJm99hX/Ccdj5CzClTDg==', N'f94eaf87-4875-49de-9ffc-fd6269066937', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e2191f6c-4824-458f-98ba-b4f6de54b10c', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a1b6420c-5dbc-4e50-9989-d123c9d0200e', N'e2191f6c-4824-458f-98ba-b4f6de54b10c')
");
        }
        
        public override void Down()
        {
            Sql(@"
DELETE FROM [dbo].[AspNetUsers] WHERE [Id]=N'a1b6420c-5dbc-4e50-9989-d123c9d0200e'
DELETE FROM [dbo].[AspNetUsers] WHERE [Id]=N'bad136f3-841a-44ab-a3c0-8075502f20f1'

DELETE FROM [dbo].[AspNetRoles] WHERE [Id]=N'e2191f6c-4824-458f-98ba-b4f6de54b10c'
");
        }
    }
}
