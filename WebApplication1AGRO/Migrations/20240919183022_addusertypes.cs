using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class addusertypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_type",
                table: "Users",
                newName: "UserTypesUserType_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypesUserType_id",
                table: "Users",
                column: "UserTypesUserType_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypesUserType_id",
                table: "Users",
                column: "UserTypesUserType_id",
                principalTable: "UserTypes",
                principalColumn: "UserType_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypesUserType_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypesUserType_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserTypesUserType_id",
                table: "Users",
                newName: "User_type");
        }
    }
}
