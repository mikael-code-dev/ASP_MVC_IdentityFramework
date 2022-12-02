using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_MVC_EntityFramework.Migrations
{
    public partial class AddedsomeRolesandaDefaultAdminaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a960eb6-a3ae-4e29-84b6-d51287485a16", "685d39b4-4508-49e8-b58f-3b0b0b774935", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66faf0bb-ab5c-4f42-9802-430f51cd8bb5", "f0da4938-7d8a-4510-b70e-e346f864f90e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "74c799b4-8c8d-4e57-a4f7-5501fcf46167", 0, "768144ff-0187-4285-9ebc-148d0c065d97", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEC27Oefp5JCtjiOcCbsdDvYvh5/MSXRGNTPeAZi60pjxEnFkzJDwMctvg+Z8HtlYug==", null, false, "2348155d-9c90-4c9a-8435-b7b554e84d53", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "66faf0bb-ab5c-4f42-9802-430f51cd8bb5", "74c799b4-8c8d-4e57-a4f7-5501fcf46167" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a960eb6-a3ae-4e29-84b6-d51287485a16");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66faf0bb-ab5c-4f42-9802-430f51cd8bb5", "74c799b4-8c8d-4e57-a4f7-5501fcf46167" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66faf0bb-ab5c-4f42-9802-430f51cd8bb5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "74c799b4-8c8d-4e57-a4f7-5501fcf46167");
        }
    }
}
