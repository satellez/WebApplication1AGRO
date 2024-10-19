using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class Contacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_DataTypes_DataType_id1",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_User_id1",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "User_id1",
                table: "Contacts",
                newName: "User_id");

            migrationBuilder.RenameColumn(
                name: "DataType_id1",
                table: "Contacts",
                newName: "DataType_id");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_User_id1",
                table: "Contacts",
                newName: "IX_Contacts_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_DataType_id1",
                table: "Contacts",
                newName: "IX_Contacts_DataType_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_DataTypes_DataType_id",
                table: "Contacts",
                column: "DataType_id",
                principalTable: "DataTypes",
                principalColumn: "DataType_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_User_id",
                table: "Contacts",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_DataTypes_DataType_id",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_User_id",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "Contacts",
                newName: "User_id1");

            migrationBuilder.RenameColumn(
                name: "DataType_id",
                table: "Contacts",
                newName: "DataType_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_User_id",
                table: "Contacts",
                newName: "IX_Contacts_User_id1");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_DataType_id",
                table: "Contacts",
                newName: "IX_Contacts_DataType_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_DataTypes_DataType_id1",
                table: "Contacts",
                column: "DataType_id1",
                principalTable: "DataTypes",
                principalColumn: "DataType_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_User_id1",
                table: "Contacts",
                column: "User_id1",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
