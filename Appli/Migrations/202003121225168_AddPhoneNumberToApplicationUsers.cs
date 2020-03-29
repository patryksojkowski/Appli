namespace Appli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberToApplicationUsers : DbMigration
    {
        public override void Up()
        {
            // replace nulls in PhoneNumber with empty strings
            Sql(@"UPDATE [dbo].[AspNetUsers]
SET PhoneNumber = ''
WHERE PhoneNumber is NULL");

            // change column not not nullable
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            // revoke all column atributtes
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());

            // replace empty strings in PhoneNumber with nulls
            Sql(@"UPDATE [dbo].[AspNetUsers]
SET PhoneNumber = NULL
WHERE PhoneNumber = ''");
        }
    }
}
