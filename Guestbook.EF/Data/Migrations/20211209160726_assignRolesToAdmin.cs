using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestbookApp.Data.Migrations
{
    public partial class assignRolesToAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO [dbo].[AspNetUserRoles] (UserId,RoleId) SELECT 'adb2235a-2399-49ec-b802-6e7394ae10dd',Id FROM [dbo].[AspNetRoles]"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                   "DELETE FROM [security].[AspNetUserRoles] WHERE UserId = 'adb2235a-2399-49ec-b802-6e7394ae10dd'"
                );
        }
    }
}
