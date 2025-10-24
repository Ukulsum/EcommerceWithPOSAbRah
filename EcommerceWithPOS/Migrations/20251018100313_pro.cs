using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWithPOS.Migrations
{
    /// <inheritdoc />
    public partial class pro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PSizes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PSizes_ProductId",
                table: "PSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Products_ProductId",
                table: "Colors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PSizes_Products_ProductId",
                table: "PSizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Products_ProductId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_PSizes_Products_ProductId",
                table: "PSizes");

            migrationBuilder.DropIndex(
                name: "IX_PSizes_ProductId",
                table: "PSizes");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ProductId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PSizes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Colors");

            migrationBuilder.AlterColumn<float>(
                name: "Quantity",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
