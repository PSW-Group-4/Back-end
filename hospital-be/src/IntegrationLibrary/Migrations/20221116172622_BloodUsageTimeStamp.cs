using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class BloodUsageTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "blood_usage",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "rHFactor",
                table: "blood_usage",
                newName: "RHFactor");

            migrationBuilder.RenameColumn(
                name: "milliliters",
                table: "blood_usage",
                newName: "Milliliters");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "blood_usage",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "blood_usage");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "blood_usage",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "RHFactor",
                table: "blood_usage",
                newName: "rHFactor");

            migrationBuilder.RenameColumn(
                name: "Milliliters",
                table: "blood_usage",
                newName: "milliliters");
        }
    }
}
