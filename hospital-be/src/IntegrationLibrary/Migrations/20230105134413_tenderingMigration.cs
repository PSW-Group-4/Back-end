using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class tenderingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Events",
                table: "tenders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "WinnerId",
                table: "tenders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tendering_events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AggregateId = table.Column<Guid>(type: "uuid", nullable: false),
                    AggregateType = table.Column<string>(type: "text", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tendering_events", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tenders_WinnerId",
                table: "tenders",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tenders_blood_banks_WinnerId",
                table: "tenders",
                column: "WinnerId",
                principalTable: "blood_banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tenders_blood_banks_WinnerId",
                table: "tenders");

            migrationBuilder.DropTable(
                name: "tendering_events");

            migrationBuilder.DropIndex(
                name: "IX_tenders_WinnerId",
                table: "tenders");

            migrationBuilder.DropColumn(
                name: "Events",
                table: "tenders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tenders");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "tenders");
        }
    }
}
