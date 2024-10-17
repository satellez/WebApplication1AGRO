using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_Category_id1",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Category_id1",
                table: "Products",
                newName: "Category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Category_id1",
                table: "Products",
                newName: "IX_Products_Category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_Category_id",
                table: "Products",
                column: "Category_id",
                principalTable: "ProductCategories",
                principalColumn: "Category_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_Category_id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Category_id",
                table: "Products",
                newName: "Category_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Category_id",
                table: "Products",
                newName: "IX_Products_Category_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_Category_id1",
                table: "Products",
                column: "Category_id1",
                principalTable: "ProductCategories",
                principalColumn: "Category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
