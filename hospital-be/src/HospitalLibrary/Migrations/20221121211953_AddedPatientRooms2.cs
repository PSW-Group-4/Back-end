using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddedPatientRooms2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<Guid>>(
                name: "BedIds",
                table: "Rooms",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientRoomId",
                table: "Beds",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beds_PatientRoomId",
                table: "Beds",
                column: "PatientRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Rooms_PatientRoomId",
                table: "Beds",
                column: "PatientRoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Rooms_PatientRoomId",
                table: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_PatientRoomId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "BedIds",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PatientRoomId",
                table: "Beds");
        }
    }
}
