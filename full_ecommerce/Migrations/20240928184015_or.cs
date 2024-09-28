using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class or : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_IdentityUser_IdentityUsersId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Ordere_OrdereId",
                table: "Ratings");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_OrdereId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Carts_IdentityUsersId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OrdereId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "IdentityUsersId",
                table: "Carts");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "OrdereId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUsersId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OrdereId",
                table: "Ratings",
                column: "OrdereId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdentityUsersId",
                table: "Carts",
                column: "IdentityUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_IdentityUser_IdentityUsersId",
                table: "Carts",
                column: "IdentityUsersId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Ordere_OrdereId",
                table: "Ratings",
                column: "OrdereId",
                principalTable: "Ordere",
                principalColumn: "Id");
        }
    }
}
