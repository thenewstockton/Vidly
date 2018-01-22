namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'026bc1bd-0ff0-4b92-b0f6-fea69bb15d8d', N'guest@gmail.com', 0, N'AFNVzLvciTySMnQM8APVU3yEav4+Sgg9bQLUYtwCjQ4m3cAX/iAUcVM7g9ikd9ls/w==', N'8f7f754a-0c1a-4a99-b7ba-730a1ea69765', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3473a6c1-f37d-4495-bcdb-d1247e07c4c3', N'phillip5914619@gmail.com', 0, N'AJaH6dIy1h+cAvnO9zfWkNQPeuuArZvrACQyvZpH0mpXC1h7LtDpiomxEmk6n4faWA==', N'df14bfb6-290d-4bca-bc40-759282215f7d', NULL, 0, 0, NULL, 1, 0, N'phillip5914619@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f364251e-8b4e-4659-8771-b63046edb319', N'admin@gmail.com', 0, N'AG7qH2KsVzL/azhQPO8D+vvNSfo90qk2+RLfCK8BJaU3cbMO2kXNP8qYvE4qEUi9Vg==', N'fd47beb2-34ce-4407-81d2-ebabd20ccc26', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'991f4ab0-4258-44d9-92e2-468ec8e7f96c', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f364251e-8b4e-4659-8771-b63046edb319', N'991f4ab0-4258-44d9-92e2-468ec8e7f96c')

");
        }
        
        public override void Down()
        {
        }
    }
}
