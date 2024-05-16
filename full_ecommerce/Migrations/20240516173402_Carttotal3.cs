using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class Carttotal3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Items_CartsId1",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "CartsId1",
                table: "CartItem",
                newName: "ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartsId1",
                table: "CartItem",
                newName: "IX_CartItem_ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Items_ItemsId",
                table: "CartItem",
                column: "ItemsId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Items_ItemsId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "CartItem",
                newName: "CartsId1");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ItemsId",
                table: "CartItem",
                newName: "IX_CartItem_CartsId1");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Items_CartsId1",
                table: "CartItem",
                column: "CartsId1",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
