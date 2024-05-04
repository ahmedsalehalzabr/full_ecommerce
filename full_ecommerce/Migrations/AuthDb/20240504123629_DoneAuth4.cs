using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class DoneAuth4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78582265-9a4b-4f31-8d9e-7d176c84a8a6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12811432-9b7c-4c30-8048-c8dc9b63ad82", "AQAAAAIAAYagAAAAEGkoVU3Z1fJossfclV5dUgubfFe9pItPkhduKrgWNwYfS3QTo2n6D5fhNadYG6NHPw==", "69e9f0a0-553a-412a-a503-21d3041a2e59" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78582265-9a4b-4f31-8d9e-7d176c84a8a6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fd6e347-60e7-4fce-90ea-7e7a454372fb", "AQAAAAIAAYagAAAAEN1RjnrRq37n3uUQNuH8gQyE24L2lIuTgnbCxDY/7ZvY8ROlRh5nNPHwe+UG86m+2Q==", "8490c7f1-bb7d-40ab-b96c-b65e42e2fa40" });
        }
    }
}
