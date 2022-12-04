using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class refactorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BloodSupply");

            migrationBuilder.AddColumn<int>(
                name: "BloodGroup",
                table: "Patients",
                type: "integer",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RhFactor",
                table: "Patients",
                type: "integer",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodGroup",
                table: "BloodSupply",
                type: "integer",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RhFactor",
                table: "BloodSupply",
                type: "integer",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "RhFactor",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "BloodSupply");

            migrationBuilder.DropColumn(
                name: "RhFactor",
                table: "BloodSupply");

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "Patients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BloodSupply",
                type: "text",
                nullable: true);
        }
    }
}
