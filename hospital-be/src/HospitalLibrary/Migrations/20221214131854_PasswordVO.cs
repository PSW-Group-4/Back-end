using HospitalLibrary.Patients.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class PasswordVO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.AlterColumn<Password>(
                name: "Password",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);*/

            migrationBuilder.Sql(
                @"
                     ALTER TABLE ""Users""
                     ALTER COLUMN ""Password"" TYPE jsonb USING (""Password""::jsonb)
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(Password),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
