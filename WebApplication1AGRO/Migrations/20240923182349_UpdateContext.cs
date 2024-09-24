using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "ProductCategories",
                newName: "Category_name");

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionPoint_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionPoint_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProdDeta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_id1 = table.Column<int>(type: "int", nullable: false),
                    QuantityStock = table.Column<int>(type: "int", nullable: false),
                    WeigthPoundsPack = table.Column<int>(type: "int", nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false),
                    MinimunQuantity = table.Column<int>(type: "int", nullable: false),
                    CollectionPoint_id1 = table.Column<int>(type: "int", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ProdDeta_id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Collections_CollectionPoint_id1",
                        column: x => x.CollectionPoint_id1,
                        principalTable: "Collections",
                        principalColumn: "CollectionPoint_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_Product_id1",
                        column: x => x.Product_id1,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    Offer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdDeta_id1 = table.Column<int>(type: "int", nullable: false),
                    QuantityOffer = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    StartOffer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOffer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.Offer_id);
                    table.ForeignKey(
                        name: "FK_offers_ProductDetails_ProdDeta_id1",
                        column: x => x.ProdDeta_id1,
                        principalTable: "ProductDetails",
                        principalColumn: "ProdDeta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_offers_ProdDeta_id1",
                table: "offers",
                column: "ProdDeta_id1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_CollectionPoint_id1",
                table: "ProductDetails",
                column: "CollectionPoint_id1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_Product_id1",
                table: "ProductDetails",
                column: "Product_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.RenameColumn(
                name: "Category_name",
                table: "ProductCategories",
                newName: "category_name");
        }
    }
}
