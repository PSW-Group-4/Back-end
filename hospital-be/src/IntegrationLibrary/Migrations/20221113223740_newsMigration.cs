using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class newsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodUsage_blood_usage_report_BloodUsageReportId",
                table: "BloodUsage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodUsage",
                table: "BloodUsage");

            migrationBuilder.RenameTable(
                name: "BloodUsage",
                newName: "blood_usage");

            migrationBuilder.RenameIndex(
                name: "IX_BloodUsage_BloodUsageReportId",
                table: "blood_usage",
                newName: "IX_blood_usage_BloodUsageReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blood_usage",
                table: "blood_usage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "blood_bank_news",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodBankId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_bank_news", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blood_bank_news_blood_banks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "blood_banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blood_requests",
                columns: table => new
                {
                    requestId = table.Column<Guid>(type: "uuid", nullable: false),
                    doctorId = table.Column<string>(type: "text", nullable: true),
                    bloodType = table.Column<int>(type: "integer", nullable: false),
                    reasonsWhyBloodIsNeeded = table.Column<string>(type: "text", nullable: true),
                    bloodAmountInMilliliters = table.Column<double>(type: "double precision", nullable: false),
                    isApproved = table.Column<bool>(type: "boolean", nullable: false),
                    rejectionComment = table.Column<string>(type: "text", nullable: true),
                    managerId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_requests", x => x.requestId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blood_bank_news_BloodBankId",
                table: "blood_bank_news",
                column: "BloodBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_blood_usage_blood_usage_report_BloodUsageReportId",
                table: "blood_usage",
                column: "BloodUsageReportId",
                principalTable: "blood_usage_report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blood_usage_blood_usage_report_BloodUsageReportId",
                table: "blood_usage");

            migrationBuilder.DropTable(
                name: "blood_bank_news");

            migrationBuilder.DropTable(
                name: "blood_requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blood_usage",
                table: "blood_usage");

            migrationBuilder.RenameTable(
                name: "blood_usage",
                newName: "BloodUsage");

            migrationBuilder.RenameIndex(
                name: "IX_blood_usage_BloodUsageReportId",
                table: "BloodUsage",
                newName: "IX_BloodUsage_BloodUsageReportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodUsage",
                table: "BloodUsage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodUsage_blood_usage_report_BloodUsageReportId",
                table: "BloodUsage",
                column: "BloodUsageReportId",
                principalTable: "blood_usage_report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
