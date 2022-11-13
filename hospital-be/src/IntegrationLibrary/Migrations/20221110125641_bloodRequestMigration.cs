using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class bloodRequestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodRequests",
                columns: table => new
                {
                    requestId = table.Column<Guid>(type: "uuid", nullable: false),
                    doctorId = table.Column<string>(type: "text", nullable: true),
                    bloodType = table.Column<int>(type: "integer", nullable: false),
                    reasonsWhyBloodIsNeeded = table.Column<string>(type: "text", nullable: true),
                    bloodAmountInMilliliters = table.Column<double>(type: "double precision", nullable: false),
                    isApproved = table.Column<bool>(type: "boolean", nullable: false),
                    rejectionComment = table.Column<string>(type: "text", nullable: true),
                    managerId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.requestId);
                    migrationBuilder.RenameColumn("BloodRequests", "bloodAmountInMilliliters", "bloodAmountInMilliliters");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("BloodRequests", "bloodAmountInMilliliters", "bloodAmountInMilliliters");
            migrationBuilder.DropTable(
                name: "BloodRequests");
        }
    }
}
