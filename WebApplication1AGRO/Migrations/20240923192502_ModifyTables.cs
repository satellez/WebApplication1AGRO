using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_offers_ProductDetails_ProdDeta_id1",
                table: "offers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_User_id_User_id1",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_offers",
                table: "offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_id",
                table: "User_id");

            migrationBuilder.RenameTable(
                name: "offers",
                newName: "Offers");

            migrationBuilder.RenameTable(
                name: "User_id",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_offers_ProdDeta_id1",
                table: "Offers",
                newName: "IX_Offers_ProdDeta_id1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Offer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_ProductDetails_ProdDeta_id1",
                table: "Offers",
                column: "ProdDeta_id1",
                principalTable: "ProductDetails",
                principalColumn: "ProdDeta_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Users_User_id1",
                table: "ProductDetails",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_ProductDetails_ProdDeta_id1",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Users_User_id1",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "offers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_ProdDeta_id1",
                table: "offers",
                newName: "IX_offers_ProdDeta_id1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_offers",
                table: "offers",
                column: "Offer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_id",
                table: "User_id",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_offers_ProductDetails_ProdDeta_id1",
                table: "offers",
                column: "ProdDeta_id1",
                principalTable: "ProductDetails",
                principalColumn: "ProdDeta_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_User_id_User_id1",
                table: "ProductDetails",
                column: "User_id1",
                principalTable: "User_id",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
