using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pwynt.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "Address", "Phone" },
                values: new object[] { 1, "Santiago", "Bauer", "634 Late Avenue", "708-577-8502" }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "Address", "Phone" },
                values: new object[] { 2, "Farrah", "Bradshaw", "1976 O Conner Street", "256-886-3736" }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "Address", "Phone" },
                values: new object[] { 3, "Ellie-May", "Ali", "3367 Pratt Avenue", "863-835-7528" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Customers]");
        }
    }
}
