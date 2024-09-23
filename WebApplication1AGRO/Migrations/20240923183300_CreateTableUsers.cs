using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_id1",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User_id",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Born_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_id", x => x.User_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_User_id1",
                table: "ProductDetails",
                column: "User_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_User_id_User_id1",
                table: "ProductDetails",
                column: "User_id1",
                principalTable: "User_id",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_User_id_User_id1",
                table: "ProductDetails");

            migrationBuilder.DropTable(
                name: "User_id");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_User_id1",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "User_id1",
                table: "ProductDetails");
        }
    }
}
