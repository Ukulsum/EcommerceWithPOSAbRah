using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWithPOS.Migrations
{
    /// <inheritdoc />
    public partial class banner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoImage",
                table: "Banners",
                newName: "LogoImagePath");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Banners",
                newName: "BannerImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoImagePath",
                table: "Banners",
                newName: "LogoImage");

            migrationBuilder.RenameColumn(
                name: "BannerImagePath",
                table: "Banners",
                newName: "Image");
        }
    }
}
