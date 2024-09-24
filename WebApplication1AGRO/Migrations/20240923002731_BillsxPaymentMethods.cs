using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class BillsxPaymentMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Bills",
                columns: table => new
                {
                    Bill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id2User_id = table.Column<int>(type: "int", nullable: false),
                    Purchase_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayMeth_idMethod_id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PayMeth_idMethod_id",
                table: "Bills",
                column: "PayMeth_idMethod_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_User_id2User_id",
                table: "Bills",
                column: "User_id2User_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
