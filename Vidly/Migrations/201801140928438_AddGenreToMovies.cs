namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genre_NumberInStock");
            DropColumn("dbo.Movies", "Genre_DateAdded");
            DropColumn("dbo.Movies", "Genre_ReleaseDate");
            DropColumn("dbo.Movies", "Genre_Name");
        }
        
        public override void Down()
        {
        }
    }
}
