using System.Collections.Generic;
using HospitalLibrary.Users.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddedEmailValueObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Patients",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Doctors",
                newName: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Patients",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Doctors",
                newName: "Email");
        }
    }
}
