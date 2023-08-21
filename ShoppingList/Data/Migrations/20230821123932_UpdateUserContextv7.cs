using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingList.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserContextv7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_Item",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Items",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_Item",
                table: "Items",
                newName: "IX_Items_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Items_UserId",
                table: "Items",
                newName: "IX_Items_Item");

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
