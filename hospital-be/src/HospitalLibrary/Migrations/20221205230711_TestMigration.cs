using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_RoomSchedules_ScheduleId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToMoves_MoveEquipmentTasks_MoveEquipmentTaskId",
                table: "EquipmentToMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentToMoves_MoveEquipmentTasks_MoveEquipmentTaskId1",
                table: "EquipmentToMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsEquipment_Rooms_DoctorRoomId",
                table: "RoomsEquipment");

            migrationBuilder.DropTable(
                name: "MoveEquipmentTasks");

            migrationBuilder.DropTable(
                name: "RoomSchedules");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentToMoves_MoveEquipmentTaskId",
                table: "EquipmentToMoves");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentToMoves_MoveEquipmentTaskId1",
                table: "EquipmentToMoves");

            migrationBuilder.DropColumn(
                name: "MoveEquipmentTaskId",
                table: "EquipmentToMoves");

            migrationBuilder.DropColumn(
                name: "MoveEquipmentTaskId1",
                table: "EquipmentToMoves");

            migrationBuilder.RenameColumn(
                name: "DoctorRoomId",
                table: "RoomsEquipment",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Appointments",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ScheduleId",
                table: "Appointments",
                newName: "IX_Appointments_RoomId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Appointments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Appointments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Appointments",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentToMoveId",
                table: "Appointments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Appointments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Appointments",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EquipmentToMoveId",
                table: "Appointments",
                column: "EquipmentToMoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_EquipmentToMoves_EquipmentToMoveId",
                table: "Appointments",
                column: "EquipmentToMoveId",
                principalTable: "EquipmentToMoves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Rooms_RoomId",
                table: "Appointments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsEquipment_Rooms_RoomId",
                table: "RoomsEquipment",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_EquipmentToMoves_EquipmentToMoveId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Rooms_RoomId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsEquipment_Rooms_RoomId",
                table: "RoomsEquipment");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_EquipmentToMoveId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "EquipmentToMoveId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomsEquipment",
                newName: "DoctorRoomId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Appointments",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                newName: "IX_Appointments_ScheduleId");

            migrationBuilder.AddColumn<Guid>(
                name: "MoveEquipmentTaskId",
                table: "EquipmentToMoves",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MoveEquipmentTaskId1",
                table: "EquipmentToMoves",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RoomSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomSchedules_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RoomSchedules_RoomId",
                table: "RoomSchedules",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_RoomSchedules_ScheduleId",
                table: "Appointments",
                column: "ScheduleId",
                principalTable: "RoomSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToMoves_MoveEquipmentTasks_MoveEquipmentTaskId",
                table: "EquipmentToMoves",
                column: "MoveEquipmentTaskId",
                principalTable: "MoveEquipmentTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentToMoves_MoveEquipmentTasks_MoveEquipmentTaskId1",
                table: "EquipmentToMoves",
                column: "MoveEquipmentTaskId1",
                principalTable: "MoveEquipmentTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsEquipment_Rooms_DoctorRoomId",
                table: "RoomsEquipment",
                column: "DoctorRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
