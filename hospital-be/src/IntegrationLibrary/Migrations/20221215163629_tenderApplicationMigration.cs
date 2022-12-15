using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class tenderApplicationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceInRSD",
                table: "tender_applications",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "ApplicationId",
                table: "tender_applications",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tender_applications",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "tender_applications",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "tender_applications",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tender_applications");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "tender_applications");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "tender_applications");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "tender_applications",
                newName: "PriceInRSD");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tender_applications",
                newName: "ApplicationId");
        }
    }
}
