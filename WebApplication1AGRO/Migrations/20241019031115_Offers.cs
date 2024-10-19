using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class Offers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ProductDetails_ProdDeta_id1",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Category_id",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "ProdDeta_id1",
                table: "Offers",
                newName: "ProdDeta_id");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_ProdDeta_id1",
                table: "Offers",
                newName: "IX_Offers_ProdDeta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ProductDetails_ProdDeta_id",
                table: "Offers",
                column: "ProdDeta_id",
                principalTable: "ProductDetails",
                principalColumn: "ProdDeta_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ProductDetails_ProdDeta_id",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "ProdDeta_id",
                table: "Offers",
                newName: "ProdDeta_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_ProdDeta_id",
                table: "Offers",
                newName: "IX_Offers_ProdDeta_id1");

            migrationBuilder.AddColumn<int>(
                name: "Category_id",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ProductDetails_ProdDeta_id1",
                table: "Offers",
                column: "ProdDeta_id1",
                principalTable: "ProductDetails",
                principalColumn: "ProdDeta_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
