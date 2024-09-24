using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class Fixall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Documents_Document_typesDocument_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypesUserType_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "DataTypes");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Users_Document_typesDocument_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypesUserType_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Document_typesDocument_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTypesUserType_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "User_name",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Category_id",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Category_id",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "User_name");

            migrationBuilder.AddColumn<int>(
                name: "Document_typesDocument_id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserTypesUserType_id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DataTypes",
                columns: table => new
                {
                    DataType_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Document_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Method_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Method_id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserType_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserType_id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType_id1 = table.Column<int>(type: "int", nullable: false),
                    User_id1 = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Bills",
                columns: table => new
                {
                    Bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayMeth_idMethod_id = table.Column<int>(type: "int", nullable: false),
                    User_id2User_id = table.Column<int>(type: "int", nullable: false),
                    Purchase_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Bill_id);
                    table.ForeignKey(
                        name: "FK_Bills_PaymentMethods_PayMeth_idMethod_id",
                        column: x => x.PayMeth_idMethod_id,
                        principalTable: "PaymentMethods",
                        principalColumn: "Method_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Users_User_id2User_id",
                        column: x => x.User_id2User_id,
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
                    Bill_id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.BillDeta_id);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_Bill_id1",
                        column: x => x.Bill_id1,
                        principalTable: "Bills",
                        principalColumn: "Bill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Document_typesDocument_id",
                table: "Users",
                column: "Document_typesDocument_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypesUserType_id",
                table: "Users",
                column: "UserTypesUserType_id");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_Bill_id1",
                table: "BillDetails",
                column: "Bill_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PayMeth_idMethod_id",
                table: "Bills",
                column: "PayMeth_idMethod_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_User_id2User_id",
                table: "Bills",
                column: "User_id2User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DataType_id1",
                table: "Contacts",
                column: "DataType_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_User_id1",
                table: "Contacts",
                column: "User_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Documents_Document_typesDocument_id",
                table: "Users",
                column: "Document_typesDocument_id",
                principalTable: "Documents",
                principalColumn: "Document_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypesUserType_id",
                table: "Users",
                column: "UserTypesUserType_id",
                principalTable: "UserTypes",
                principalColumn: "UserType_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
