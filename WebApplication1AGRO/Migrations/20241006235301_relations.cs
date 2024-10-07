using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
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

            migrationBuilder.RenameColumn(
                name: "UserTypesUserType_id",
                table: "Users",
                newName: "UserType_id");

            migrationBuilder.RenameColumn(
                name: "Document_typesDocument_id",
                table: "Users",
                newName: "Document_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypesUserType_id",
                table: "Users",
                newName: "IX_Users_UserType_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Document_typesDocument_id",
                table: "Users",
                newName: "IX_Users_Document_id");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Documents_Document_id",
                table: "Users",
                column: "Document_id",
                principalTable: "Documents",
                principalColumn: "Document_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserType_id",
                table: "Users",
                column: "UserType_id",
                principalTable: "UserTypes",
                principalColumn: "UserType_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Documents_Document_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserType_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserType_id",
                table: "Users",
                newName: "UserTypesUserType_id");

            migrationBuilder.RenameColumn(
                name: "Document_id",
                table: "Users",
                newName: "Document_typesDocument_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserType_id",
                table: "Users",
                newName: "IX_Users_UserTypesUserType_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Document_id",
                table: "Users",
                newName: "IX_Users_Document_typesDocument_id");

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
