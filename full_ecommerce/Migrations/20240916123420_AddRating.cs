using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommuntRating",
                table: "Ordere");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Ordere");
        }
    }
}
