using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddedAllergies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Patients_PatientId",
                table: "Allergies");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_PatientId",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Allergies");

            migrationBuilder.CreateTable(
                name: "PatientAllergies",
                columns: table => new
                {
                    AllergiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAllergies", x => new { x.AllergiesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_PatientsId",
                table: "PatientAllergies",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAllergies");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "Allergies",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_PatientId",
                table: "Allergies",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Patients_PatientId",
                table: "Allergies",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
