using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class newsMigration2 : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "blood_bank_news",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "blood_bank_news");

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
