using System;
using System.Collections.Generic;
using HospitalLibrary.Symptoms.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class SymptomRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportSymptom");

            migrationBuilder.AddColumn<List<Symptom>>(
                name: "Symptoms",
                table: "Reports",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Reports");

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
    }
}
