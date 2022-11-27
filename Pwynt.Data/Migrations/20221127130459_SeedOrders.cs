using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pwynt.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "FinalPrice", "CustomerId" },
                values: new object[] { 1, "2022-7-04", 125.97, 1 }
            );

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "FinalPrice", "CustomerId" },
                values: new object[] { 2, "2022-11-09", 959.00, 2 }
            );

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "FinalPrice", "CustomerId" },
                values: new object[] { 3, "2022-9-15", 1475.98, 3 }
            );

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "FinalPrice", "CustomerId" },
                values: new object[] { 4, "2022-7-06", 199.99, 1 }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Orders]");
        }
    }
}
