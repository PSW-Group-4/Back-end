using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class ddd_person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_ChoosenDoctorId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "ChoosenDoctorId",
                table: "Patients",
                newName: "ChosenDoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_ChoosenDoctorId",
                table: "Patients",
                newName: "IX_Patients_ChosenDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_ChosenDoctorId",
                table: "Patients",
                column: "ChosenDoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_ChosenDoctorId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "ChosenDoctorId",
                table: "Patients",
                newName: "ChoosenDoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_ChosenDoctorId",
                table: "Patients",
                newName: "IX_Patients_ChoosenDoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_ChoosenDoctorId",
                table: "Patients",
                column: "ChoosenDoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
