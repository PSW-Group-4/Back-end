using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class resetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE IF EXISTS blood_bank_news CASCADE");
            migrationBuilder.Sql("DROP TABLE IF EXISTS blood_requests CASCADE");
            migrationBuilder.Sql("DROP TABLE IF EXISTS blood_usage CASCADE");
            migrationBuilder.Sql("DROP TABLE IF EXISTS blood_usage_report CASCADE");
            migrationBuilder.Sql("DROP TABLE IF EXISTS blood_banks_config CASCADE");
            migrationBuilder.Sql("DROP TABLE IF EXISTS blood_banks CASCADE");
            migrationBuilder.CreateTable(
                name: "blood_banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ServerAddress = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blood_requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    RHFactor = table.Column<int>(type: "integer", nullable: false),
                    ReasonsWhyBloodIsNeeded = table.Column<string>(type: "text", nullable: true),
                    BloodAmountInMilliliters = table.Column<double>(type: "double precision", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionComment = table.Column<string>(type: "text", nullable: true),
                    ManagerId = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blood_usage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RHFactor = table.Column<int>(type: "integer", nullable: false),
                    Milliliters = table.Column<double>(type: "double precision", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_usage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blood_bank_news",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodBankId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
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
                    ReportConfigurationId = table.Column<Guid>(type: "uuid", nullable: true),
                    timeOfCreation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_blood_bank_news_BloodBankId",
                table: "blood_bank_news",
                column: "BloodBankId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blood_bank_news");

            migrationBuilder.DropTable(
                name: "blood_requests");

            migrationBuilder.DropTable(
                name: "blood_usage");

            migrationBuilder.DropTable(
                name: "blood_usage_report");

            migrationBuilder.DropTable(
                name: "blood_banks_config");

            migrationBuilder.DropTable(
                name: "blood_banks");
        }
    }
}
