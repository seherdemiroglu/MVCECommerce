using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCECommerce.Migrations
{
    /// <inheritdoc />
    public partial class Indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Categories_CategoryId",
                table: "Specifications");

            migrationBuilder.AlterColumn<string>(
                name: "NameTr",
                table: "Specifications",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Specifications",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_NameEn",
                table: "Specifications",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_NameTr",
                table: "Specifications",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_SpecificationId",
                table: "ProductSpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameEn",
                table: "Products",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameTr",
                table: "Products",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Date",
                table: "Comments",
                column: "Date",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameEn",
                table: "Categories",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameTr",
                table: "Categories",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_NameEn",
                table: "Catalogs",
                column: "NameEn");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_NameTr",
                table: "Catalogs",
                column: "NameTr");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecifications_Products_ProductId",
                table: "ProductSpecifications",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSpecifications_Specifications_SpecificationId",
                table: "ProductSpecifications",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Categories_CategoryId",
                table: "Specifications",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecifications_Products_ProductId",
                table: "ProductSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSpecifications_Specifications_SpecificationId",
                table: "ProductSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Specifications_Categories_CategoryId",
                table: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_Specifications_NameEn",
                table: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_Specifications_NameTr",
                table: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_ProductSpecifications_SpecificationId",
                table: "ProductSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_Products_NameEn",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_NameTr",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Date",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NameEn",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NameTr",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_NameEn",
                table: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_NameTr",
                table: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Name",
                table: "Brands");

            migrationBuilder.AlterColumn<string>(
                name: "NameTr",
                table: "Specifications",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "Specifications",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Specifications_Categories_CategoryId",
                table: "Specifications",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
