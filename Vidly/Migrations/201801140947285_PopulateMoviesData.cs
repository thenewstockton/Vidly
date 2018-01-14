namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId]) VALUES ('Hangover', 1)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId]) VALUES ('Die Hard', 2)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId]) VALUES ('The Terminator', 3)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId]) VALUES ('Toy Story', 4)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId]) VALUES ('Titanic', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
