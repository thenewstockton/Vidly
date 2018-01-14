namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Genres] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (1, 'Comedy', '2009-11-06', '2016-05-04', 5)");
            Sql("INSERT INTO [dbo].[Genres] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (2, 'Die Hard', '1988-7-12', '2015-11-22', 11)");
            Sql("INSERT INTO [dbo].[Genres] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (3, 'The Terminator', '1985-3-29', '2014-4-8', 0)");
            Sql("INSERT INTO [dbo].[Genres] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (4, 'Toy Story', '1995-11-19', '2013-1-5', 55)");
            Sql("INSERT INTO [dbo].[Genres] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (5, 'Titanic', '1997-12-20', '2012-12-12', 100)");
        }
        
        public override void Down()
        {
        }
    }
}
