using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManchesterAirportParking.Repository.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "18afe167-238c-4e0a-b7dc-0d9d955326e5");

            migrationBuilder.AddColumn<Guid>(
                name: "Reference",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "13b44979-82ca-4e10-81db-74c069810b69", 0, "8163d165-21e8-4462-85e5-4b78123cffd2", "admin@ca.vu", true, false, null, "ADMIN@CA.VU", null, "AQAAAAIAAYagAAAAEEezm6cccbvYCwep7X73CYKonRusqb5Og6bZRm282OYmgoPLLAkWTNOD8mXu6YHP5g==", null, true, "ddfc4fbc-9cd3-46ec-a0bf-4da9df048753", false, "admin@ca.vu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13b44979-82ca-4e10-81db-74c069810b69");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "18afe167-238c-4e0a-b7dc-0d9d955326e5", 0, "45f829c5-8f49-496b-829b-1839acd51487", "admin@ca.vu", true, false, null, "ADMIN@CA.VU", null, "AQAAAAIAAYagAAAAEBgNy9MWJctfiUfgVIXeHYiWu6exvq6+big1cFkqSnr1r+Utg6Qg78uabEAx48yTfw==", null, true, "40597f56-065f-4e04-9287-377f418ee338", false, "admin@ca.vu" });
        }
    }
}
