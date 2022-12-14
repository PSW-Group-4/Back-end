using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class tableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blood_subscription_responces");

            migrationBuilder.DropColumn(
                name: "BloodBankName",
                table: "blood_subscriptions");

            migrationBuilder.DropColumn(
                name: "DeliveryDay",
                table: "blood_subscriptions");

            migrationBuilder.CreateTable(
                name: "blood_subscription_responses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uuid", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Version = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_subscription_responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blood_subscription_responses_blood_subscriptions_Subscripti~",
                        column: x => x.SubscriptionId,
                        principalTable: "blood_subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blood_subscription_responses_SubscriptionId",
                table: "blood_subscription_responses",
                column: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blood_subscription_responses");

            migrationBuilder.AddColumn<string>(
                name: "BloodBankName",
                table: "blood_subscriptions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryDay",
                table: "blood_subscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "blood_subscription_responces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SubscriptionId = table.Column<Guid>(type: "uuid", nullable: true),
                    Version = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_subscription_responces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blood_subscription_responces_blood_subscriptions_Subscripti~",
                        column: x => x.SubscriptionId,
                        principalTable: "blood_subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blood_subscription_responces_SubscriptionId",
                table: "blood_subscription_responces",
                column: "SubscriptionId");
        }
    }
}
