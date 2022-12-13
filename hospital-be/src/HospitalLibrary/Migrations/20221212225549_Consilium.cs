using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class Consilium : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Reports_Appointment_AppointmentId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "Appointment");*/

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Reports",
                newName: "MedicalAppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_AppointmentId",
                table: "Reports",
                newName: "IX_Reports_MedicalAppointmentId");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConsiliumDoctor",
                columns: table => new
                {
                    ConsiliumsId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsiliumDoctor", x => new { x.ConsiliumsId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Appointments_ConsiliumsId",
                        column: x => x.ConsiliumsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsiliumDoctor_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsiliumDoctor_DoctorsId",
                table: "ConsiliumDoctor",
                column: "DoctorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Appointments_MedicalAppointmentId",
                table: "Reports",
                column: "MedicalAppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Appointments_MedicalAppointmentId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "ConsiliumDoctor");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "MedicalAppointmentId",
                table: "Reports",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_MedicalAppointmentId",
                table: "Reports",
                newName: "IX_Reports_AppointmentId");

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    TempId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_Appointment_TempId1", x => x.TempId1);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Appointment_AppointmentId",
                table: "Reports",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "TempId1",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
