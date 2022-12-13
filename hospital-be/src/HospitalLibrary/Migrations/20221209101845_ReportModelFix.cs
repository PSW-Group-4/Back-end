using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class ReportModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Doctors_DoctorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Patients_PatientId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_DoctorId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Reports",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_PatientId",
                table: "Reports",
                newName: "IX_Reports_AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Appointments_AppointmentId",
                table: "Reports",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Appointments_AppointmentId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Reports",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_AppointmentId",
                table: "Reports",
                newName: "IX_Reports_PatientId");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DoctorId",
                table: "Reports",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Doctors_DoctorId",
                table: "Reports",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Patients_PatientId",
                table: "Reports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
