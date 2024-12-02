using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.SaaS.Accelerator.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSubUsersStartEndDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "SubscriptionUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "SubscriptionUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.CreateIndex(
                name: "IX_Email_AmpSubId",
                table: "SubscriptionUsers",
                columns: new[] { "UserEmail", "AMPSubscriptionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Email_AmpSubId",
                table: "SubscriptionUsers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "SubscriptionUsers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "SubscriptionUsers");
        }
    }
}
