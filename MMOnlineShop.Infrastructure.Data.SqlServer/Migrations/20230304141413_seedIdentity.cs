using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMOnlineShop.Infrastructure.Data.SqlServer.Migrations
{
    public partial class seedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "usr",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "89f10674-2356-4a2a-a23d-bbffb0991eb0", "Admin", "Admin" });

            migrationBuilder.InsertData(
                schema: "usr",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "4dbfd9fc-f6f5-4b91-b09f-0fc2ff81f908", "Customer", "Customer" });

            migrationBuilder.InsertData(
                schema: "usr",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "7e03fa9e-d7d2-4a30-a938-c55677a0136b", "mahdiabbaszadeh1376@gmail.com", true, "Admin", "Admin", false, null, null, "admin", "AQAAAAIAAYagAAAAED/cRtQ4UBSzryqP1DiXh+EwMSWYjYI3sksteTsLltLE8eMha01c+XoqfV8r3fT4Ew==", null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                schema: "usr",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "usr",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "usr",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "usr",
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "usr",
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
