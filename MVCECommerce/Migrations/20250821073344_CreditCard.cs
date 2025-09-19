using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCECommerce.Migrations
{
    /// <inheritdoc />
    public partial class CreditCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreditCardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installments_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), "axess" },
                    { new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff1"), "world" },
                    { new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff2"), "bonus" },
                    { new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff3"), "maximum" },
                    { new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff4"), "advantage" },
                    { new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff5"), "bankkart" }
                });

            migrationBuilder.InsertData(
                table: "Installments",
                columns: new[] { "Id", "Count", "CreditCardId", "Rate" },
                values: new object[,]
                {
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc000"), 2, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), 1m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc001"), 3, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), 1m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc002"), 6, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), 1m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc003"), 8, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), 1.1m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc004"), 9, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), 1.20m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc005"), 12, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), 1.30m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc006"), 2, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff1"), 1m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc007"), 3, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff1"), 1m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc008"), 6, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff1"), 1m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc009"), 8, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff1"), 1.15m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc010"), 9, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff1"), 1.25m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc011"), 12, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff1"), 1.35m },
                    { new Guid("7b059ae7-c6b2-4f5e-8316-204bb01fc012"), 4, new Guid("022988e2-d3c2-4619-8b9d-57e0d1374ff0"), 1m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Installments_CreditCardId",
                table: "Installments",
                column: "CreditCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "CreditCards");
        }
    }
}
