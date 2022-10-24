using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddedAdressAndPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("7ccdbb6c-5801-40f9-8303-912a24e2a277"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7e8eca3d-5548-40e2-96a2-07fca4d79e0c"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "StreetNumber" },
                values: new object[] { new Guid("7e8eca3d-5548-40e2-96a2-07fca4d79e0c"), "Kkinda", "Serbia", "Ulica", "11" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AddressId", "Birthdate", "Blocked", "Email", "Gender", "Jmbg", "Lbo", "Name", "PhoneNumber", "Surname" },
                values: new object[] { new Guid("7ccdbb6c-5801-40f9-8303-912a24e2a277"), new Guid("7e8eca3d-5548-40e2-96a2-07fca4d79e0c"), new DateTime(2022, 10, 23, 21, 59, 9, 307, DateTimeKind.Local).AddTicks(6590), false, "mail@gmail.com", 0, "123456789", "343434", "Strahinja", "061-333-44-77", "Erakovic" });
        }
    }
}
