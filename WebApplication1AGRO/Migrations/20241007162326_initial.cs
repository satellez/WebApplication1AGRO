using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionPoint_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionPoint_id);
                });

            migrationBuilder.CreateTable(
                name: "DataTypes",
                columns: table => new
                {
                    DataType_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTypes", x => x.DataType_id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Document_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Document_id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Method_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Method_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Category_id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserType_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserType_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_id1 = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_Category_id1",
                        column: x => x.Category_id1,
                        principalTable: "ProductCategories",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Born_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserType_id = table.Column<int>(type: "int", nullable: false),
                    Document_id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Users_Documents_Document_id",
                        column: x => x.Document_id,
                        principalTable: "Documents",
                        principalColumn: "Document_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserType_id",
                        column: x => x.UserType_id,
                        principalTable: "UserTypes",
                        principalColumn: "UserType_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Purchase_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method_id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Bill_id);
                    table.ForeignKey(
                        name: "FK_Bills_PaymentMethods_Method_id",
                        column: x => x.Method_id,
                        principalTable: "PaymentMethods",
                        principalColumn: "Method_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bills_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_id1 = table.Column<int>(type: "int", nullable: false),
                    DataType_id1 = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Contact_id);
                    table.ForeignKey(
                        name: "FK_Contacts_DataTypes_DataType_id1",
                        column: x => x.DataType_id1,
                        principalTable: "DataTypes",
                        principalColumn: "DataType_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_User_id1",
                        column: x => x.User_id1,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
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
                    User_id1 = table.Column<int>(type: "int", nullable: false),
                    CollectionPoint_id1 = table.Column<int>(type: "int", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_ProductDetails_Users_User_id1",
                        column: x => x.User_id1,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    BillDeta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bill_id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.BillDeta_id);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_Bill_id",
                        column: x => x.Bill_id,
                        principalTable: "Bills",
                        principalColumn: "Bill_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetails_Products_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Offer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdDeta_id1 = table.Column<int>(type: "int", nullable: false),
                    QuantityOffer = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    StartOffer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOffer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Offer_id);
                    table.ForeignKey(
                        name: "FK_Offers_ProductDetails_ProdDeta_id1",
                        column: x => x.ProdDeta_id1,
                        principalTable: "ProductDetails",
                        principalColumn: "ProdDeta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_Bill_id",
                table: "BillDetails",
                column: "Bill_id");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_Product_id",
                table: "BillDetails",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Method_id",
                table: "Bills",
                column: "Method_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_User_id",
                table: "Bills",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DataType_id1",
                table: "Contacts",
                column: "DataType_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_User_id1",
                table: "Contacts",
                column: "User_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProdDeta_id1",
                table: "Offers",
                column: "ProdDeta_id1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_CollectionPoint_id1",
                table: "ProductDetails",
                column: "CollectionPoint_id1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_Product_id1",
                table: "ProductDetails",
                column: "Product_id1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_User_id1",
                table: "ProductDetails",
                column: "User_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_id1",
                table: "Products",
                column: "Category_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Document_id",
                table: "Users",
                column: "Document_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserType_id",
                table: "Users",
                column: "UserType_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "DataTypes");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
