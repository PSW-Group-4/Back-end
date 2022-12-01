using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class tenderApplicationMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "tenders",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "tenders",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Version",
                table: "tenders",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenderId",
                table: "TenderApplications",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "BloodBankId",
                table: "TenderApplications",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_TenderApplications_BloodBankId",
                table: "TenderApplications",
                column: "BloodBankId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderApplications_TenderId",
                table: "TenderApplications",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderApplications_blood_banks_BloodBankId",
                table: "TenderApplications",
                column: "BloodBankId",
                principalTable: "blood_banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderApplications_tenders_TenderId",
                table: "TenderApplications",
                column: "TenderId",
                principalTable: "tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderApplications_blood_banks_BloodBankId",
                table: "TenderApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderApplications_tenders_TenderId",
                table: "TenderApplications");

            migrationBuilder.DropIndex(
                name: "IX_TenderApplications_BloodBankId",
                table: "TenderApplications");

            migrationBuilder.DropIndex(
                name: "IX_TenderApplications_TenderId",
                table: "TenderApplications");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "tenders");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "tenders");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "tenders",
                newName: "DatePosted");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenderId",
                table: "TenderApplications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BloodBankId",
                table: "TenderApplications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
