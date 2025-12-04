using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "IsActive", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8506), true, false, "Admin", new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8508) },
                    { 2, new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8513), true, false, "Student", new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8513) },
                    { 3, new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8515), true, false, "Teacher", new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8516) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Password", "RoleId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8733), "admin@gmail.com", false, null, 1, new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8734) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
