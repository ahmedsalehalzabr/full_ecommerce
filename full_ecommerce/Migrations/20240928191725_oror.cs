using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class oror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Ordere_OrdereId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_OrdereId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OrdereId",
                table: "Carts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrdereId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrdereId",
                table: "Carts",
                column: "OrdereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Ordere_OrdereId",
                table: "Carts",
                column: "OrdereId",
                principalTable: "Ordere",
                principalColumn: "Id");
        }
    }
}
