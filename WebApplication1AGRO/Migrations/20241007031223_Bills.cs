using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class Bills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PaymentMethods_PayMeth_idMethod_id",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_User_id2User_id",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "User_id2User_id",
                table: "Bills",
                newName: "User_id");

            migrationBuilder.RenameColumn(
                name: "PayMeth_idMethod_id",
                table: "Bills",
                newName: "Method_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_User_id2User_id",
                table: "Bills",
                newName: "IX_Bills_User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_PayMeth_idMethod_id",
                table: "Bills",
                newName: "IX_Bills_Method_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PaymentMethods_Method_id",
                table: "Bills",
                column: "Method_id",
                principalTable: "PaymentMethods",
                principalColumn: "Method_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_User_id",
                table: "Bills",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PaymentMethods_Method_id",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_User_id",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "Bills",
                newName: "User_id2User_id");

            migrationBuilder.RenameColumn(
                name: "Method_id",
                table: "Bills",
                newName: "PayMeth_idMethod_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_User_id",
                table: "Bills",
                newName: "IX_Bills_User_id2User_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_Method_id",
                table: "Bills",
                newName: "IX_Bills_PayMeth_idMethod_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PaymentMethods_PayMeth_idMethod_id",
                table: "Bills",
                column: "PayMeth_idMethod_id",
                principalTable: "PaymentMethods",
                principalColumn: "Method_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_User_id2User_id",
                table: "Bills",
                column: "User_id2User_id",
                principalTable: "Users",
                principalColumn: "User_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
