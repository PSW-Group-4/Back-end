using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class moveequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoveEquipmentTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomScheduleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveEquipmentTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoveEquipmentTasks_RoomSchedules_RoomScheduleId",
                        column: x => x.RoomScheduleId,
                        principalTable: "RoomSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentToMoves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    MoveEquipmentTaskId = table.Column<Guid>(type: "uuid", nullable: true),
                    MoveEquipmentTaskId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentToMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentToMoves_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentToMoves_MoveEquipmentTasks_MoveEquipmentTaskId",
                        column: x => x.MoveEquipmentTaskId,
                        principalTable: "MoveEquipmentTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentToMoves_MoveEquipmentTasks_MoveEquipmentTaskId1",
                        column: x => x.MoveEquipmentTaskId1,
                        principalTable: "MoveEquipmentTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToMoves_EquipmentId",
                table: "EquipmentToMoves",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToMoves_MoveEquipmentTaskId",
                table: "EquipmentToMoves",
                column: "MoveEquipmentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentToMoves_MoveEquipmentTaskId1",
                table: "EquipmentToMoves",
                column: "MoveEquipmentTaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_MoveEquipmentTasks_RoomScheduleId",
                table: "MoveEquipmentTasks",
                column: "RoomScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentToMoves");

            migrationBuilder.DropTable(
                name: "MoveEquipmentTasks");
        }
    }
}
