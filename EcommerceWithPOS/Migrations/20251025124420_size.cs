using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWithPOS.Migrations
{
    /// <inheritdoc />
    public partial class size : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Items_ItemId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ItemsVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ItemId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ProductVariants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ProductVariants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemsVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsVariants_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsVariants_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsVariants_PSizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "PSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ItemId",
                table: "ProductVariants",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsVariants_ColorId",
                table: "ItemsVariants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsVariants_ItemId",
                table: "ItemsVariants",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsVariants_SizeId",
                table: "ItemsVariants",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Items_ItemId",
                table: "ProductVariants",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
