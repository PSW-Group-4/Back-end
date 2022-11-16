using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class EquipmentFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Rooms_DoctorRoomId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_DoctorRoomId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "DoctorRoomId",
                table: "Equipments");

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    arrivalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsEquipment",
                columns: table => new
                {
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorRoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsEquipment", x => new { x.DoctorRoomId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_RoomsEquipment_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsEquipment_Rooms_DoctorRoomId",
                        column: x => x.DoctorRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientId",
                table: "Admissions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_RoomId",
                table: "Admissions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsEquipment_EquipmentId",
                table: "RoomsEquipment",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "RoomsEquipment");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Equipments",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorRoomId",
                table: "Equipments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DoctorRoomId",
                table: "Equipments",
                column: "DoctorRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Rooms_DoctorRoomId",
                table: "Equipments",
                column: "DoctorRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
