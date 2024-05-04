using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class DoneAuth3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78582265-9a4b-4f31-8d9e-7d176c84a8a6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fd6e347-60e7-4fce-90ea-7e7a454372fb", "AQAAAAIAAYagAAAAEN1RjnrRq37n3uUQNuH8gQyE24L2lIuTgnbCxDY/7ZvY8ROlRh5nNPHwe+UG86m+2Q==", "8490c7f1-bb7d-40ab-b96c-b65e42e2fa40" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78582265-9a4b-4f31-8d9e-7d176c84a8a6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50dd3454-e14d-4e61-b5e5-c1b92960bf1f", "AQAAAAIAAYagAAAAEH9IkBSMVtHTduFfSfn/5eb8um6uBuKmrVDAN6CpogyU08QIMrfuEZRb9C0Bp9aUJg==", "6dc3a5b4-0ad4-48a5-bbb2-9419f7417795" });
        }
    }
}
