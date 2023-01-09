using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class renovationsession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MedicalAppointmentSchedulingSessionEvents",
                newName: "Discriminator");

            migrationBuilder.CreateTable(
                name: "RenovationSessionAggregateRoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeOfRenovation = table.Column<int>(type: "integer", nullable: true),
                    RoomRenovationPlans = table.Column<string>(type: "text", nullable: true),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenovationSessionAggregateRoots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RenovationSessionEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    NewRoomsCreated_RoomRenovationPlans = table.Column<string>(type: "text", nullable: true),
                    RoomRenovationPlans = table.Column<string>(type: "text", nullable: true),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TimeframeCreated_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TimeframeCreated_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TypeOfRenovationChosen = table.Column<int>(type: "integer", nullable: true),
                    AggregateId = table.Column<Guid>(type: "uuid", nullable: false),
                    OccurrenceTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenovationSessionEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RenovationSessionAggregateRoots");

            migrationBuilder.DropTable(
                name: "RenovationSessionEvents");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "MedicalAppointmentSchedulingSessionEvents",
                newName: "Type");
        }
    }
}
