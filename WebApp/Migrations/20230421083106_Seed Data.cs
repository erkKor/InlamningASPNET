using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4e44692b-6f88-4afc-89d1-dacd8bee6c3a", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UploadProfileImage", "UserName" },
                values: new object[] { "b3dede5e-568e-401b-b6ea-d693e3f0bad4", 0, null, "c6169945-c297-41c0-b2ad-a3e833b984aa", "admin@domain.com", false, " ", "Adminlastname", false, null, null, null, "AQAAAAIAAYagAAAAEMl9Rdw52bllMkvVPt5woheV256dXdk/lWnMuw+hdgsX/qQO8pIdePJcImpNn5waLQ==", null, false, "3cfcd206-17ab-4158-872e-4057b5458331", false, null, " " });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4e44692b-6f88-4afc-89d1-dacd8bee6c3a", "b3dede5e-568e-401b-b6ea-d693e3f0bad4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4e44692b-6f88-4afc-89d1-dacd8bee6c3a", "b3dede5e-568e-401b-b6ea-d693e3f0bad4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e44692b-6f88-4afc-89d1-dacd8bee6c3a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3dede5e-568e-401b-b6ea-d693e3f0bad4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aa91ef5-077b-42f7-9d90-ac51b1bcb54c", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UploadProfileImage", "UserName" },
                values: new object[] { "d82ca148-7de8-4532-8f4f-a2168e862567", 0, null, "240f79f5-2c97-4264-b963-71427b93cf90", null, false, "Adminname", "Adminlastname", false, null, null, null, "AQAAAAIAAYagAAAAENebBWy8CFTQdvbuEg7Dv7fHeSVR6ELMOiCk/vcxZnzGQKErpT0uprZJANO0WUcAVw==", null, false, "5437243e-38eb-4fae-9352-b374950ebc32", false, null, "admin" });
        }
    }
}
