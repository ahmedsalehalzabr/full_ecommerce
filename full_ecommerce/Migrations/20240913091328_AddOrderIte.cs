using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderIte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "Ordere");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ordere");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Ordere");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdereId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrdereId",
                table: "Items",
                column: "OrdereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Ordere_OrdereId",
                table: "Items",
                column: "OrdereId",
                principalTable: "Ordere",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Ordere_OrdereId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrdereId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrdereId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Ordere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Ordere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Ordere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
