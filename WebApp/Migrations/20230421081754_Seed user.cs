using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Seeduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7083a62c-1c56-477f-8bf8-f36ee3910d99");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aa91ef5-077b-42f7-9d90-ac51b1bcb54c", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UploadProfileImage", "UserName" },
                values: new object[] { "d82ca148-7de8-4532-8f4f-a2168e862567", 0, null, "240f79f5-2c97-4264-b963-71427b93cf90", null, false, "Adminname", "Adminlastname", false, null, null, null, "AQAAAAIAAYagAAAAENebBWy8CFTQdvbuEg7Dv7fHeSVR6ELMOiCk/vcxZnzGQKErpT0uprZJANO0WUcAVw==", null, false, "5437243e-38eb-4fae-9352-b374950ebc32", false, null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa91ef5-077b-42f7-9d90-ac51b1bcb54c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d82ca148-7de8-4532-8f4f-a2168e862567");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7083a62c-1c56-477f-8bf8-f36ee3910d99", null, "Admin", "ADMIN" });
        }
    }
}
