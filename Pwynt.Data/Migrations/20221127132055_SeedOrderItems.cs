using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pwynt.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Quantity", "TotalAmount", "ProductId", "OrderId" },
                values: new object[] { 1, 1, 25.99, 1, 1 }
            );

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Quantity", "TotalAmount", "ProductId", "OrderId" },
                values: new object[] { 2, 2, 99.98, 5, 1 }
            );

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Quantity", "TotalAmount", "ProductId", "OrderId" },
                values: new object[] { 3, 1, 959.00, 3, 2 }
            );

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Quantity", "TotalAmount", "ProductId", "OrderId" },
                values: new object[] { 4, 1, 25.99, 1, 3 }
            );

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Quantity", "TotalAmount", "ProductId", "OrderId" },
                values: new object[] { 5, 1, 1449.99, 4, 3 }
            );

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "Quantity", "TotalAmount", "ProductId", "OrderId" },
                values: new object[] { 6, 1, 199.99, 8, 4 }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [OrderItem]");
        }
    }
}
