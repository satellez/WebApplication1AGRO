using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class ProductDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Collections_CollectionPoint_id1",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_Product_id1",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Users_User_id1",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "User_id1",
                table: "ProductDetails",
                newName: "User_id");

            migrationBuilder.RenameColumn(
                name: "Product_id1",
                table: "ProductDetails",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "CollectionPoint_id1",
                table: "ProductDetails",
                newName: "CollectionPoint_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_User_id1",
                table: "ProductDetails",
                newName: "IX_ProductDetails_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_Product_id1",
                table: "ProductDetails",
                newName: "IX_ProductDetails_Product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_CollectionPoint_id1",
                table: "ProductDetails",
                newName: "IX_ProductDetails_CollectionPoint_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Collections_CollectionPoint_id",
                table: "ProductDetails",
                column: "CollectionPoint_id",
                principalTable: "Collections",
                principalColumn: "CollectionPoint_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_Product_id",
                table: "ProductDetails",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Users_User_id",
                table: "ProductDetails",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Collections_CollectionPoint_id",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_Product_id",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Users_User_id",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "ProductDetails",
                newName: "User_id1");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "ProductDetails",
                newName: "Product_id1");

            migrationBuilder.RenameColumn(
                name: "CollectionPoint_id",
                table: "ProductDetails",
                newName: "CollectionPoint_id1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_User_id",
                table: "ProductDetails",
                newName: "IX_ProductDetails_User_id1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_Product_id",
                table: "ProductDetails",
                newName: "IX_ProductDetails_Product_id1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_CollectionPoint_id",
                table: "ProductDetails",
                newName: "IX_ProductDetails_CollectionPoint_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Collections_CollectionPoint_id1",
                table: "ProductDetails",
                column: "CollectionPoint_id1",
                principalTable: "Collections",
                principalColumn: "CollectionPoint_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_Product_id1",
                table: "ProductDetails",
                column: "Product_id1",
                principalTable: "Products",
                principalColumn: "Product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Users_User_id1",
                table: "ProductDetails",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
