using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddedMedicines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Rooms_PatientRoomId",
                table: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_PatientRoomId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "PatientRoomId",
                table: "Beds");

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientRoomId",
                table: "Beds",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beds_PatientRoomId",
                table: "Beds",
                column: "PatientRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Rooms_PatientRoomId",
                table: "Beds",
                column: "PatientRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
