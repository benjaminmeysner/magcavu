using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManchesterAirportParking.Repository.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e271cdff-fc37-4e99-a375-e69107b40239");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "18afe167-238c-4e0a-b7dc-0d9d955326e5", 0, "45f829c5-8f49-496b-829b-1839acd51487", "admin@ca.vu", true, false, null, "ADMIN@CA.VU", null, "AQAAAAIAAYagAAAAEBgNy9MWJctfiUfgVIXeHYiWu6exvq6+big1cFkqSnr1r+Utg6Qg78uabEAx48yTfw==", null, true, "40597f56-065f-4e04-9287-377f418ee338", false, "admin@ca.vu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18afe167-238c-4e0a-b7dc-0d9d955326e5");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e271cdff-fc37-4e99-a375-e69107b40239", 0, "97ead73c-9bca-4ed2-bc35-264c1df241ad", "admin@ca.vu", true, false, null, "ADMIN@CA.VU", null, "AQAAAAIAAYagAAAAEJiPUZwbyJxmICoXG1+ROyZ+H0OLRy1TjL5E0kFaU01uhaD4f6Q3EVh2WK0bRQQkrg==", null, true, "8aec954e-4332-41f6-9475-47d234fd9f65", false, "admin@ca.vu" });
        }
    }
}
