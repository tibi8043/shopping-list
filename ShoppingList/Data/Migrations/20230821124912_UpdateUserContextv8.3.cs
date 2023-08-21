using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingList.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserContextv83 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Items",
                newName: "AppUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_UserId",
                table: "Items",
                newName: "IX_Items_AppUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_AppUsersId",
                table: "Items",
                column: "AppUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_AppUsersId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "AppUsersId",
                table: "Items",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_AppUsersId",
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
    }
}
