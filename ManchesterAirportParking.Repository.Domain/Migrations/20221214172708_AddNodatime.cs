using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManchesterAirportParking.Repository.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddNodatime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "379f6321-9bbc-41b1-af02-564c5867a01e");

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                table: "Reservations",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Reservations",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e271cdff-fc37-4e99-a375-e69107b40239", 0, "97ead73c-9bca-4ed2-bc35-264c1df241ad", "admin@ca.vu", true, false, null, "ADMIN@CA.VU", null, "AQAAAAIAAYagAAAAEJiPUZwbyJxmICoXG1+ROyZ+H0OLRy1TjL5E0kFaU01uhaD4f6Q3EVh2WK0bRQQkrg==", null, true, "8aec954e-4332-41f6-9475-47d234fd9f65", false, "admin@ca.vu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e271cdff-fc37-4e99-a375-e69107b40239");

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "379f6321-9bbc-41b1-af02-564c5867a01e", 0, "6180fc80-2267-43f9-a62f-9f75f05d4c52", "admin@ca.vu", true, false, null, "ADMIN@CA.VU", null, "AQAAAAIAAYagAAAAEIC3xgRLeHxqghdVnV6YeGfqh4xOud0aaxod3I+kkCyBEFg1ZwoMt3yg7Snj53UjOQ==", null, true, "5fd0b0ee-d853-4289-bc16-a61747274dec", false, "admin@ca.vu" });
        }
    }
}
