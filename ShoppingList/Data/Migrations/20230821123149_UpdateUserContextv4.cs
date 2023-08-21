using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingList.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserContextv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_Item",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "Item",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_User",
                table: "Items",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_Item",
                table: "Items",
                column: "Item",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_User",
                table: "Items",
                column: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_Item",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_User",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_User",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "Item",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_Item",
                table: "Items",
                column: "Item",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
