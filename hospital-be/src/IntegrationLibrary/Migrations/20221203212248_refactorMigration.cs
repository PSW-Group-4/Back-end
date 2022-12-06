using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class refactorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BloodProducts",
                table: "tenders",
                newName: "Blood");

            migrationBuilder.RenameColumn(
                name: "BloodProducts",
                table: "blood_subscriptions",
                newName: "Blood");

            migrationBuilder.RenameColumn(
                name: "BloodProduct_BloodType",
                table: "blood_requests",
                newName: "Blood_BloodType");

            migrationBuilder.RenameColumn(
                name: "BloodProduct_Amount",
                table: "blood_requests",
                newName: "Blood_Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Blood",
                table: "tenders",
                newName: "BloodProducts");

            migrationBuilder.RenameColumn(
                name: "Blood",
                table: "blood_subscriptions",
                newName: "BloodProducts");

            migrationBuilder.RenameColumn(
                name: "Blood_BloodType",
                table: "blood_requests",
                newName: "BloodProduct_BloodType");

            migrationBuilder.RenameColumn(
                name: "Blood_Amount",
                table: "blood_requests",
                newName: "BloodProduct_Amount");
        }
    }
}
