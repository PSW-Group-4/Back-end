using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class renovationappointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RenovationAppointment_Type",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomRenovationPlans",
                table: "Appointments",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenovationAppointment_Type",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RoomRenovationPlans",
                table: "Appointments");
        }
    }
}
