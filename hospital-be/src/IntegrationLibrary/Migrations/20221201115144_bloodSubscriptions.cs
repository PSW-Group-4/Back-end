using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class bloodSubscriptions : Migration
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

            migrationBuilder.CreateTable(
                name: "BloodSubscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BloodProducts = table.Column<string>(type: "text", nullable: true),
                    BloodBankName = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Version = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodSubscription", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodSubscription");

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
