using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class maplocationchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomMaps_Rooms_RoomId",
                table: "RoomMaps");

            migrationBuilder.DropTable(
                name: "BuildingMaps");

            migrationBuilder.DropTable(
                name: "FloorMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomMaps",
                table: "RoomMaps");

            migrationBuilder.RenameTable(
                name: "RoomMaps",
                newName: "MapItem");

            migrationBuilder.RenameIndex(
                name: "IX_RoomMaps_RoomId",
                table: "MapItem",
                newName: "IX_MapItem_RoomId");

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "MapItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "MapItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateY",
                table: "MapItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateX",
                table: "MapItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "MapItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MapItem",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FloorId",
                table: "MapItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapItem",
                table: "MapItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MapItem_BuildingId",
                table: "MapItem",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_MapItem_FloorId",
                table: "MapItem",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MapItem_Buildings_BuildingId",
                table: "MapItem",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MapItem_Floors_FloorId",
                table: "MapItem",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MapItem_Rooms_RoomId",
                table: "MapItem",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapItem_Buildings_BuildingId",
                table: "MapItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MapItem_Floors_FloorId",
                table: "MapItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MapItem_Rooms_RoomId",
                table: "MapItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapItem",
                table: "MapItem");

            migrationBuilder.DropIndex(
                name: "IX_MapItem_BuildingId",
                table: "MapItem");

            migrationBuilder.DropIndex(
                name: "IX_MapItem_FloorId",
                table: "MapItem");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "MapItem");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MapItem");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "MapItem");

            migrationBuilder.RenameTable(
                name: "MapItem",
                newName: "RoomMaps");

            migrationBuilder.RenameIndex(
                name: "IX_MapItem_RoomId",
                table: "RoomMaps",
                newName: "IX_RoomMaps_RoomId");

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "RoomMaps",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "RoomMaps",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateY",
                table: "RoomMaps",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoordinateX",
                table: "RoomMaps",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomMaps",
                table: "RoomMaps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BuildingMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: true),
                    CoordinateX = table.Column<int>(type: "integer", nullable: false),
                    CoordinateY = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingMaps_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FloorMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CoordinateX = table.Column<int>(type: "integer", nullable: false),
                    CoordinateY = table.Column<int>(type: "integer", nullable: false),
                    FloorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloorMaps_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingMaps_BuildingId",
                table: "BuildingMaps",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorMaps_FloorId",
                table: "FloorMaps",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMaps_Rooms_RoomId",
                table: "RoomMaps",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
