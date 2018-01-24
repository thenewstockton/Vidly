namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[Movies] SET [GenreId] = 1 WHERE [Name]='Titanic'");
        }
        
        public override void Down()
        {
        }
    }
}
