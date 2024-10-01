using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class BillDetailsxProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Product_id1",
                table: "BillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_Product_id1",
                table: "BillDetails",
                column: "Product_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Products_Product_id1",
                table: "BillDetails",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Products_Product_id1",
                table: "BillDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_Product_id1",
                table: "BillDetails");

            migrationBuilder.DropColumn(
                name: "Product_id1",
                table: "BillDetails");
        }
    }
}
