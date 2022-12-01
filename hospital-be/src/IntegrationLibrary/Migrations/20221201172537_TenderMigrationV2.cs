using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class TenderMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "tenders");

            migrationBuilder.DropColumn(
                name: "RHFactor",
                table: "tenders");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "tenders",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "tenders",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "BloodTypeTitle",
                table: "blood_requests",
                newName: "BloodGroup");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "tenders",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "BloodProducts",
                table: "tenders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "tenders",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodProducts",
                table: "tenders");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "tenders");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "tenders",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tenders",
                newName: "DatePosted");

            migrationBuilder.RenameColumn(
                name: "BloodGroup",
                table: "blood_requests",
                newName: "BloodTypeTitle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deadline",
                table: "tenders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "tenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RHFactor",
                table: "tenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
