using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class configReportMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blood_banks_config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodBankId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestFrequency = table.Column<int>(type: "integer", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_banks_config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blood_banks_config_blood_banks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "blood_banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blood_usage_report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodBankId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReportConfigurationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_usage_report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blood_usage_report_blood_banks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "blood_banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blood_usage_report_blood_banks_config_ReportConfigurationId",
                        column: x => x.ReportConfigurationId,
                        principalTable: "blood_banks_config",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodUsage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    rHFactor = table.Column<int>(type: "integer", nullable: false),
                    milliliters = table.Column<double>(type: "double precision", nullable: false),
                    BloodUsageReportId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodUsage_blood_usage_report_BloodUsageReportId",
                        column: x => x.BloodUsageReportId,
                        principalTable: "blood_usage_report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blood_banks_config_BloodBankId",
                table: "blood_banks_config",
                column: "BloodBankId");

            migrationBuilder.CreateIndex(
                name: "IX_blood_usage_report_BloodBankId",
                table: "blood_usage_report",
                column: "BloodBankId");

            migrationBuilder.CreateIndex(
                name: "IX_blood_usage_report_ReportConfigurationId",
                table: "blood_usage_report",
                column: "ReportConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodUsage_BloodUsageReportId",
                table: "BloodUsage",
                column: "BloodUsageReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodUsage");

            migrationBuilder.DropTable(
                name: "blood_usage_report");

            migrationBuilder.DropTable(
                name: "blood_banks_config");
        }
    }
}
