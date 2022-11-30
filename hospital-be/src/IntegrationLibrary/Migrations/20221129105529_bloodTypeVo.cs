using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class bloodTypeVo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "blood_usage");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "blood_requests");

            migrationBuilder.RenameColumn(
                name: "RHFactor",
                table: "blood_usage",
                newName: "RhFactor");

            migrationBuilder.RenameColumn(
                name: "RHFactor",
                table: "blood_requests",
                newName: "RhFactor");

            migrationBuilder.AlterColumn<int>(
                name: "RhFactor",
                table: "blood_usage",
                type: "integer",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeTitle",
                table: "blood_usage",
                type: "integer",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RhFactor",
                table: "blood_requests",
                type: "integer",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "BloodTypeTitle",
                table: "blood_requests",
                type: "integer",
                maxLength: 1,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodTypeTitle",
                table: "blood_usage");

            migrationBuilder.DropColumn(
                name: "BloodTypeTitle",
                table: "blood_requests");

            migrationBuilder.RenameColumn(
                name: "RhFactor",
                table: "blood_usage",
                newName: "RHFactor");

            migrationBuilder.RenameColumn(
                name: "RhFactor",
                table: "blood_requests",
                newName: "RHFactor");

            migrationBuilder.AlterColumn<int>(
                name: "RHFactor",
                table: "blood_usage",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "blood_usage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RHFactor",
                table: "blood_requests",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "blood_requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
