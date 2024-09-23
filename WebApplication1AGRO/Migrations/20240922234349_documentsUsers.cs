using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class documentsUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Document_typesDocument_id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Document_typesDocument_id",
                table: "Users",
                column: "Document_typesDocument_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Documents_Document_typesDocument_id",
                table: "Users",
                column: "Document_typesDocument_id",
                principalTable: "Documents",
                principalColumn: "Document_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Documents_Document_typesDocument_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Document_typesDocument_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Document_typesDocument_id",
                table: "Users");
        }
    }
}
