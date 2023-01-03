using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class _20221230001315_Added_MedicalAppointmentSchedulingSessionEvents_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalAppointmentSchedulingSessionEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Speciality = table.Column<string>(type: "text", nullable: true),
                    SelectedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Selection = table.Column<int>(type: "integer", nullable: true),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: true),
                    AggregateId = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrenceTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAppointmentSchedulingSessionEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAppointmentSchedulingSessionEvents_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalAppointmentSchedulingSessionEvents_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointmentSchedulingSessionEvents_DoctorId",
                table: "MedicalAppointmentSchedulingSessionEvents",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointmentSchedulingSessionEvents_PatientId",
                table: "MedicalAppointmentSchedulingSessionEvents",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalAppointmentSchedulingSessionEvents");
        }
    }
}
