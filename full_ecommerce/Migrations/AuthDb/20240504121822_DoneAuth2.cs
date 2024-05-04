using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace full_ecommerce.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class DoneAuth2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78582265-9a4b-4f31-8d9e-7d176c84a8a6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "50dd3454-e14d-4e61-b5e5-c1b92960bf1f", "AQAAAAIAAYagAAAAEH9IkBSMVtHTduFfSfn/5eb8um6uBuKmrVDAN6CpogyU08QIMrfuEZRb9C0Bp9aUJg==", "123", "6dc3a5b4-0ad4-48a5-bbb2-9419f7417795" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78582265-9a4b-4f31-8d9e-7d176c84a8a6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "a69f5fc4-611a-49eb-b0f6-6aaa5f3f8cbc", "AQAAAAIAAYagAAAAEOuUdaIlJRzC9f0irr9eol303qKEaKlR6Dj565k4UQDYFVZiKvmQNPwEdLya3WCr4w==", null, "fb0abcdb-c006-4824-9785-6741fb9e6afa" });
        }
    }
}
