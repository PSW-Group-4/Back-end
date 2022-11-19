using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class BloodReportExclusion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blood_usage_blood_usage_report_BloodUsageReportId",
                table: "blood_usage");

            migrationBuilder.DropIndex(
                name: "IX_blood_usage_BloodUsageReportId",
                table: "blood_usage");

            migrationBuilder.DropColumn(
                name: "BloodUsageReportId",
                table: "blood_usage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BloodUsageReportId",
                table: "blood_usage",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_blood_usage_BloodUsageReportId",
                table: "blood_usage",
                column: "BloodUsageReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_blood_usage_blood_usage_report_BloodUsageReportId",
                table: "blood_usage",
                column: "BloodUsageReportId",
                principalTable: "blood_usage_report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
