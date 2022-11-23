using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class roomschedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Rooms_RoomId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Appointments",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_RoomId",
                table: "Appointments",
                newName: "IX_Appointments_ScheduleId");

            migrationBuilder.CreateTable(
                name: "RoomSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_RoomSchedules_ScheduleId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "RoomSchedules");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Appointments",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ScheduleId",
                table: "Appointments",
                newName: "IX_Appointments_RoomId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Appointments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Appointments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Rooms_RoomId",
                table: "Appointments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
