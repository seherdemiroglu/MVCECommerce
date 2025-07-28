using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCECommerce.Migrations
{
    /// <inheritdoc />
    public partial class CatalogidtoCarousel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CarouselImages",
                newName: "CatalogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CatalogId",
                table: "CarouselImages",
                newName: "CategoryId");
        }
    }
}
