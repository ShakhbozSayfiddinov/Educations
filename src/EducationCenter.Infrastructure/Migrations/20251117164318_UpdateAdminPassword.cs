using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(7726), new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(7728) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(7733), new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(7734) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(7735), new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(8257), "web123$", new DateTime(2025, 11, 17, 16, 43, 16, 917, DateTimeKind.Utc).AddTicks(8257) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8506), new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8508) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8513), new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8515), new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8733), null, new DateTime(2025, 11, 17, 16, 37, 5, 358, DateTimeKind.Utc).AddTicks(8734) });
        }
    }
}
