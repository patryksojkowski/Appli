namespace Appli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            var query = "INSERT INTO Genres (Id, Name) VALUES " +
                "(1, 'Comedy'), " +
                "(2, 'Family'), " +
                "(3, 'Romance'), " +
                "(4, 'Action')";
            Sql(query);
        }

        public override void Down()
        {
        }
    }
}
