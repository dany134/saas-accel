using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.SaaS.Accelerator.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscriptionUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AMPSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionUsers_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeteringLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    AmpSubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DimensionId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeteringLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeteringLogs_MeteredDimensions_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "MeteredDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeteringLogs_SubscriptionUsers_SubscriptionUserId",
                        column: x => x.SubscriptionUserId,
                        principalTable: "SubscriptionUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeteringLogs_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeteringLogs_DimensionId",
                table: "MeteringLogs",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeteringLogs_SubscriptionId",
                table: "MeteringLogs",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeteringLogs_SubscriptionUserId",
                table: "MeteringLogs",
                column: "SubscriptionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionUsers_SubscriptionId",
                table: "SubscriptionUsers",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeteringLogs");

            migrationBuilder.DropTable(
                name: "SubscriptionUsers");
        }
    }
}
