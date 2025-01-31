using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_user_UserId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_product_UserId",
                table: "Product",
                newName: "IX_Product_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UserId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "product");

            migrationBuilder.RenameIndex(
                name: "IX_Product_UserId",
                table: "product",
                newName: "IX_product_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_user_UserId",
                table: "product",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
