namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[Movies] SET [ReleaseDate]='2009-11-06', [DateAdded]='2016-05-04', [NumberInStock]=5 WHERE [Name]='Hangover'");
            Sql("UPDATE [dbo].[Movies] SET [ReleaseDate]='1988-7-12', [DateAdded]='2015-11-22', [NumberInStock]=11 WHERE [Name]='Die Hard'");
            Sql("UPDATE [dbo].[Movies] SET [ReleaseDate]='1985-3-29', [DateAdded]='2014-4-8', [NumberInStock]=0 WHERE [Name]='The Terminator'");
            Sql("UPDATE [dbo].[Movies] SET [ReleaseDate]='1995-11-19', [DateAdded]='2013-1-5', [NumberInStock]=55 WHERE [Name]='Toy Story'");
            Sql("UPDATE [dbo].[Movies] SET [ReleaseDate]='1997-12-20', [DateAdded]='2012-12-12', [NumberInStock]=5 WHERE [Name]='Titanic'");                
        }
        
        public override void Down()
        {
        }
    }
}
