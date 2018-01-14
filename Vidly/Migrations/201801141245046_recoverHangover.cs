namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recoverHangover : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Movies] ([Name],[GenreId], [ReleaseDate],[DateAdded],[NumberInStock]) VALUES ('Hangover', 1,'2009-11-06','2016-05-04',5)");
        }
        
        public override void Down()
        {
        }
    }
}
