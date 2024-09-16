using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommuntRating",
                table: "Ordere");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Ordere");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ratings = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CommuntRating = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdereRating");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.AddColumn<string>(
                name: "CommuntRating",
                table: "Ordere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Ordere",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
