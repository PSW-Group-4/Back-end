using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class JmbgValueObjectAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.AlterColumn<Jmbg>(
                            name: "Jmbg",
                            table: "Patients",
                            type: "jsonb",
                            nullable: true,
                            oldClrType: typeof(string),
                            oldType: "text",
                            oldNullable: true);*/

            migrationBuilder.Sql(
                @"
                     ALTER TABLE ""Patients""
                     ALTER COLUMN ""Jmbg"" TYPE jsonb USING (""Jmbg""::jsonb)
                ");

            /*migrationBuilder.AlterColumn<Jmbg>(
                name: "Jmbg",
                table: "Doctors",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);*/
            migrationBuilder.Sql(
                @"
                     ALTER TABLE ""Doctors""
                     ALTER COLUMN ""Jmbg"" TYPE jsonb USING (""Jmbg""::jsonb)
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Jmbg",
                table: "Patients",
                type: "text",
                nullable: true,
                oldClrType: typeof(Jmbg),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Jmbg",
                table: "Doctors",
                type: "text",
                nullable: true,
                oldClrType: typeof(Jmbg),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
