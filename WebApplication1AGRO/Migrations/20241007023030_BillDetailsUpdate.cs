using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class BillDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Bills_Bill_id1",
                table: "BillDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Products_Product_id1",
                table: "BillDetails");

            migrationBuilder.RenameColumn(
                name: "Product_id1",
                table: "BillDetails",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "Bill_id1",
                table: "BillDetails",
                newName: "Bill_id");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetails_Product_id1",
                table: "BillDetails",
                newName: "IX_BillDetails_Product_id");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetails_Bill_id1",
                table: "BillDetails",
                newName: "IX_BillDetails_Bill_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bills_Bill_id",
                table: "BillDetails",
                column: "Bill_id",
                principalTable: "Bills",
                principalColumn: "Bill_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Products_Product_id",
                table: "BillDetails",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Bills_Bill_id",
                table: "BillDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Products_Product_id",
                table: "BillDetails");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "BillDetails",
                newName: "Product_id1");

            migrationBuilder.RenameColumn(
                name: "Bill_id",
                table: "BillDetails",
                newName: "Bill_id1");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetails_Product_id",
                table: "BillDetails",
                newName: "IX_BillDetails_Product_id1");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetails_Bill_id",
                table: "BillDetails",
                newName: "IX_BillDetails_Bill_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Bills_Bill_id1",
                table: "BillDetails",
                column: "Bill_id1",
                principalTable: "Bills",
                principalColumn: "Bill_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Products_Product_id1",
                table: "BillDetails",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
