namespace MovieRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
          Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0dc3dfcd-cb6e-4709-935a-889ac65d6c87', N'guest@me.com', 0, N'ACSmQX2isOsAcAa9dwTQCPQvBMlXZrI5Pq/CXX04clC3g3ZFQt/56PVquO2+nnpR7Q==', N'5039d016-a82f-496d-8c37-149d6d332fd0', NULL, 0, 0, NULL, 1, 0, N'guest@me.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8ab70fa2-4638-4cbb-904f-0efeca816be0', N'admin@me.com', 0, N'AGYOFRQKv8Iluh8eypcQ0iaJrnsUisFnDgjkrAhy7k8/zjTYdfMwMY1BxF20xqVNKg==', N'ecefef2a-33f5-4b64-8831-9c978c5e0406', NULL, 0, 0, NULL, 1, 0, N'admin@me.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8045d9d2-82c6-41b2-bd3b-9fab033ba201', N'CanManageMovie')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ab70fa2-4638-4cbb-904f-0efeca816be0', N'8045d9d2-82c6-41b2-bd3b-9fab033ba201')
             ");
        }
        
        public override void Down()
        {

        }
    }
}
