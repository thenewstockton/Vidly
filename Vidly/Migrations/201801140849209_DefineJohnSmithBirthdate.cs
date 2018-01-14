namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineJohnSmithBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[Customers] SET [Birthdate] = '1980-01-01' WHERE [Name]='John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
