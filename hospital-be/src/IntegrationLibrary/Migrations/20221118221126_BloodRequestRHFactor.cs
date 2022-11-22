using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class BloodRequestRHFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "blood_usage",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "rHFactor",
                table: "blood_usage",
                newName: "RHFactor");

            migrationBuilder.RenameColumn(
                name: "milliliters",
                table: "blood_usage",
                newName: "Milliliters");

            migrationBuilder.RenameColumn(
                name: "rejectionComment",
                table: "blood_requests",
                newName: "RejectionComment");

            migrationBuilder.RenameColumn(
                name: "reasonsWhyBloodIsNeeded",
                table: "blood_requests",
                newName: "ReasonsWhyBloodIsNeeded");

            migrationBuilder.RenameColumn(
                name: "managerId",
                table: "blood_requests",
                newName: "ManagerId");

            migrationBuilder.RenameColumn(
                name: "isApproved",
                table: "blood_requests",
                newName: "IsApproved");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "blood_requests",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "bloodType",
                table: "blood_requests",
                newName: "BloodType");

            migrationBuilder.RenameColumn(
                name: "bloodAmountInMilliliters",
                table: "blood_requests",
                newName: "BloodAmountInMilliliters");

            migrationBuilder.RenameColumn(
                name: "requestId",
                table: "blood_requests",
                newName: "RequestId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "blood_requests",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RHFactor",
                table: "blood_requests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "blood_requests");

            migrationBuilder.DropColumn(
                name: "RHFactor",
                table: "blood_requests");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "blood_usage",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "RHFactor",
                table: "blood_usage",
                newName: "rHFactor");

            migrationBuilder.RenameColumn(
                name: "Milliliters",
                table: "blood_usage",
                newName: "milliliters");

            migrationBuilder.RenameColumn(
                name: "RejectionComment",
                table: "blood_requests",
                newName: "rejectionComment");

            migrationBuilder.RenameColumn(
                name: "ReasonsWhyBloodIsNeeded",
                table: "blood_requests",
                newName: "reasonsWhyBloodIsNeeded");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "blood_requests",
                newName: "managerId");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "blood_requests",
                newName: "isApproved");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "blood_requests",
                newName: "doctorId");

            migrationBuilder.RenameColumn(
                name: "BloodType",
                table: "blood_requests",
                newName: "bloodType");

            migrationBuilder.RenameColumn(
                name: "BloodAmountInMilliliters",
                table: "blood_requests",
                newName: "bloodAmountInMilliliters");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "blood_requests",
                newName: "requestId");
        }
    }
}
