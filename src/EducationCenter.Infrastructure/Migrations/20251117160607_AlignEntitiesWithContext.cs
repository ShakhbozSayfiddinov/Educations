using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlignEntitiesWithContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Teacher_TeacherId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherScience_Science_ScienceID",
                table: "TeacherScience");

            migrationBuilder.RenameColumn(
                name: "ScienceID",
                table: "TeacherScience",
                newName: "ScienceId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherScience_TeacherId_ScienceID",
                table: "TeacherScience",
                newName: "IX_TeacherScience_TeacherId_ScienceId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherScience_ScienceID",
                table: "TeacherScience",
                newName: "IX_TeacherScience_ScienceId");

            migrationBuilder.RenameColumn(
                name: "ExoerienceYear",
                table: "Teacher",
                newName: "ExperienceYears");

            migrationBuilder.RenameColumn(
                name: "Dagree",
                table: "Teacher",
                newName: "Degree");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Teacher_TeacherId",
                table: "Attachment",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherScience_Science_ScienceId",
                table: "TeacherScience",
                column: "ScienceId",
                principalTable: "Science",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ArgumentNullException.ThrowIfNull(migrationBuilder);

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Teacher_TeacherId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherScience_Science_ScienceId",
                table: "TeacherScience");

            migrationBuilder.RenameColumn(
                name: "ScienceId",
                table: "TeacherScience",
                newName: "ScienceID");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherScience_TeacherId_ScienceId",
                table: "TeacherScience",
                newName: "IX_TeacherScience_TeacherId_ScienceID");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherScience_ScienceId",
                table: "TeacherScience",
                newName: "IX_TeacherScience_ScienceID");

            migrationBuilder.RenameColumn(
                name: "ExperienceYears",
                table: "Teacher",
                newName: "ExoerienceYear");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Teacher",
                newName: "Dagree");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Teacher_TeacherId",
                table: "Attachment",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherScience_Science_ScienceID",
                table: "TeacherScience",
                column: "ScienceID",
                principalTable: "Science",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
