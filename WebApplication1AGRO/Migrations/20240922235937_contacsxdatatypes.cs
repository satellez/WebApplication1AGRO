using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1AGRO.Migrations
{
    /// <inheritdoc />
    public partial class contacsxdatatypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataType_id1",
                table: "Contacts",
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

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DataType_id1",
                table: "Contacts",
                column: "DataType_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_DataTypes_DataType_id1",
                table: "Contacts",
                column: "DataType_id1",
                principalTable: "DataTypes",
                principalColumn: "DataType_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_DataTypes_DataType_id1",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "DataTypes");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_DataType_id1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DataType_id1",
                table: "Contacts");
        }
    }
}
