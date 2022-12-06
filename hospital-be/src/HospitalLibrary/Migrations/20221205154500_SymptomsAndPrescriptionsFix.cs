using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class SymptomsAndPrescriptionsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_Reports_ReportId",
                table: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Symptoms_ReportId",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "Symptoms");

            migrationBuilder.CreateTable(
                name: "ReportSymptom",
                columns: table => new
                {
                    ReportsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SymptomsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSymptom", x => new { x.ReportsId, x.SymptomsId });
                    table.ForeignKey(
                        name: "FK_ReportSymptom_Reports_ReportsId",
                        column: x => x.ReportsId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSymptom_Symptoms_SymptomsId",
                        column: x => x.SymptomsId,
                        principalTable: "Symptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportSymptom_SymptomsId",
                table: "ReportSymptom",
                column: "SymptomsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportSymptom");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportId",
                table: "Symptoms",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_ReportId",
                table: "Symptoms",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_Reports_ReportId",
                table: "Symptoms",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
