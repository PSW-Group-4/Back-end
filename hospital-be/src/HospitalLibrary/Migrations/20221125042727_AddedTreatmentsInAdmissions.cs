using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddedTreatmentsInAdmissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TreatmentId",
                table: "Admissions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_TreatmentId",
                table: "Admissions",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Treatments_TreatmentId",
                table: "Admissions",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Treatments_TreatmentId",
                table: "Admissions");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_TreatmentId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Admissions");
        }
    }
}
