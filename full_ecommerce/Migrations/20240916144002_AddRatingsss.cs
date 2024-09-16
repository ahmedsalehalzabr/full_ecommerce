using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdereRating");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdereId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OrdereId",
                table: "Ratings",
                column: "OrdereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Ordere_OrdereId",
                table: "Ratings",
                column: "OrdereId",
                principalTable: "Ordere",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Ordere_OrdereId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_OrdereId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "OrdereId",
                table: "Ratings");

            migrationBuilder.CreateTable(
                name: "OrdereRating",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdereRating", x => new { x.OrdersId, x.RatingsId });
                    table.ForeignKey(
                        name: "FK_OrdereRating_Ordere_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Ordere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdereRating_Ratings_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdereRating_RatingsId",
                table: "OrdereRating",
                column: "RatingsId");
        }
    }
}
