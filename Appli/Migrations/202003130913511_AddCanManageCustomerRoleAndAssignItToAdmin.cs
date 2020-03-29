namespace Appli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCanManageCustomerRoleAndAssignItToAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3f3a573c-e3ae-4404-872f-441776a224ca', N'CanManageCustomers');
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a1b6420c-5dbc-4e50-9989-d123c9d0200e', N'3f3a573c-e3ae-4404-872f-441776a224ca');
");
        }
        
        public override void Down()
        {
            Sql(@"
DELETE FROM [dbo].[AspNetRoles] ([Id], [Name]) WHERE Id=N'3f3a573c-e3ae-4404-872f-441776a224ca';
");
        }
    }
}
