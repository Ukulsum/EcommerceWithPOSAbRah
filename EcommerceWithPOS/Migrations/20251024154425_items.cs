using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWithPOS.Migrations
{
    /// <inheritdoc />
    public partial class items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ProductVariants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    TaxId = table.Column<int>(type: "int", nullable: true),
                    PurchasePrice = table.Column<float>(type: "real", nullable: false),
                    RetailPrice = table.Column<float>(type: "real", nullable: false),
                    WholeSalePrice = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    TaxMethod = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Taxs_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemsVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_ProductImages_ItemId",
                table: "ProductImages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BrandId",
                table: "Items",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TaxId",
                table: "Items",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UnitId",
                table: "Items",
                column: "UnitId");

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
                name: "FK_ProductImages_Items_ItemId",
                table: "ProductImages",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Items_ItemId",
                table: "ProductVariants",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Items_ItemId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Items_ItemId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ItemsVariants");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ItemId",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ItemId",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ProductImages");
        }
    }
}
