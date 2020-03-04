namespace VidlyModified.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class sedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1268d6a9-58ec-48ea-a0a2-40ad2ad35aa2', N'admin@vidly.com', 0, N'ANVFs9qCb+uq9TAo2k3kvSpQDIIpTi71tB0rXBiZF48IoVK6bCD/9nAmzGWA9W4Kgw==', N'a5d6db4b-8e3f-456a-87ef-3289b2e53d53', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f4390ff-987e-4fdf-a36b-8426f78d9f62', N'guest@vidly.com', 0, N'ACtD1/EzA2aL2Flcl7T498H9mLnrwgX/Uxxh8aCp6xuli4n3bvymwZHoIzvNF+BCqg==', N'2ff5a890-1a14-4be8-a719-45da6b801d61', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cceb8c3e-364c-40e3-979d-c82e0c8ba343', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1268d6a9-58ec-48ea-a0a2-40ad2ad35aa2', N'cceb8c3e-364c-40e3-979d-c82e0c8ba343')

 

");
        }

        public override void Down()
        {
        }
    }
}
