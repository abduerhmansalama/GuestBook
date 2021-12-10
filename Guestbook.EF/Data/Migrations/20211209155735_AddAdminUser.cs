using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestbookApp.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO[dbo].[AspNetUsers]([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES(N'adb2235a-2399-49ec-b802-6e7394ae10dd', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHCpPiLji5gCafwly81Ze5XvWi5WBjEerEfvkBERuoXt4TFuHBq/cmYgS9TJOjoBSg==', N'BXEAEZHUDH5K7VVFU3GLJO2ODXSKEDWV', N'14b1cb8a-18c7-4d76-9dd1-4780243d7945', NULL, 0, 0, NULL, 1, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id = 'adb2235a-2399-49ec-b802-6e7394ae10dd'");
        }
    }
}
