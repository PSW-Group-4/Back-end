using System.Collections.Generic;
using HospitalLibrary.Users.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class susactiv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<SuspiciousActivity>>(
                name: "suspicious_activities",
                table: "Users",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "suspicious_activities",
                table: "Users");
        }
    }
}
