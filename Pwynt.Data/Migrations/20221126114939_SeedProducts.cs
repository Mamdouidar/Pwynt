using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pwynt.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 1, "Beats Studio Buds - True Wireless Noise Cancelling Earbuds", 25.99, 1 }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 2, "Full Motion TV Monitor Wall Mount", 29.33, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 3, "Lenovo 2022 Newest Ideapad 3 Laptop", 959.00, 2 }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 4, "ROG Strix G10 Gaming Desktop PC", 1449.99, 2 }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 5, "Castle Art Supplies 72 Colored Pencils Set", 49.99, 3 }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 6, "NIECHO 66 Inches Silver Easel Stand with Tray", 19.99, 3 }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 7, "SereneLife SLPAC8 Portable Air Conditioner", 319.99, 4 }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CategoryId" },
                values: new object[] { 8, "Ninja DZ201 Foodi 8 Quart 6-in-1 DualZone 2-Basket Air Fryer", 199.99, 4 }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Products]");
        }
    }
}
