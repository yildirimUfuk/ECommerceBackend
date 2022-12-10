using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_Customerid",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Customerid",
                table: "Orders",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Customerid",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "Customerid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_Customerid",
                table: "Orders",
                column: "Customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
