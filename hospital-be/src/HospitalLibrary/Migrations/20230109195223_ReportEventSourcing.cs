using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class ReportEventSourcing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalAppointmentReportSessionEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    NumberOfMedicines = table.Column<int>(type: "integer", nullable: true),
                    ReportText = table.Column<string>(type: "text", nullable: true),
                    NumberOfSymptoms = table.Column<int>(type: "integer", nullable: true),
                    SelectedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Selection = table.Column<int>(type: "integer", nullable: true),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: true),
                    AggregateId = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrenceTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAppointmentReportSessionEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalAppointmentReportSessionEvents_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointmentReportSessionEvents_DoctorId",
                table: "MedicalAppointmentReportSessionEvents",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalAppointmentReportSessionEvents");
        }
    }
}
