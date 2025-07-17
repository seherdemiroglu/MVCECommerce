using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCECommerce.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_EntityBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EntityBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecifications", x => new { x.ProductId, x.SpecificationId });
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GivenName = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProvinceId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Brands__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarouselImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarouselImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarouselImages__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Catalogs__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categories__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingAddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<Guid>(type: "uuid", nullable: true),
                    NameTr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionTr = table.Column<string>(type: "text", nullable: true),
                    DescriptionEn = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameTr = table.Column<string>(type: "text", nullable: true),
                    NameEn = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogProduct",
                columns: table => new
                {
                    CatalogsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogProduct", x => new { x.CatalogsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CatalogProduct_Catalogs_CatalogsId",
                        column: x => x.CatalogsId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductImages__EntityBase_Id",
                        column: x => x.Id,
                        principalTable: "_EntityBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 2, "Adıyaman" },
                    { 3, "Afyonkarahisar" },
                    { 4, "Ağrı" },
                    { 5, "Amasya" },
                    { 6, "Ankara" },
                    { 7, "Antalya" },
                    { 8, "Artvin" },
                    { 9, "Aydın" },
                    { 10, "Balıkesir" },
                    { 11, "Bilecik" },
                    { 12, "Bingöl" },
                    { 13, "Bitlis" },
                    { 14, "Bolu" },
                    { 15, "Burdur" },
                    { 16, "Bursa" },
                    { 17, "Çanakkale" },
                    { 18, "Çankırı" },
                    { 19, "Çorum" },
                    { 20, "Denizli" },
                    { 21, "Diyarbakır" },
                    { 22, "Edirne" },
                    { 23, "Elazığ" },
                    { 24, "Erzincan" },
                    { 25, "Erzurum" },
                    { 26, "Eskişehir" },
                    { 27, "Gaziantep" },
                    { 28, "Giresun" },
                    { 29, "Gümüşhane" },
                    { 30, "Hakkari" },
                    { 31, "Hatay" },
                    { 32, "Isparta" },
                    { 33, "Mersin" },
                    { 34, "İstanbul" },
                    { 35, "İzmir" },
                    { 36, "Kars" },
                    { 37, "Kastamonu" },
                    { 38, "Kayseri" },
                    { 39, "Kırklareli" },
                    { 40, "Kırşehir" },
                    { 41, "Kocaeli" },
                    { 42, "Konya" },
                    { 43, "Kütahya" },
                    { 44, "Malatya" },
                    { 45, "Manisa" },
                    { 46, "Kahramanmaraş" },
                    { 47, "Mardin" },
                    { 48, "Muğla" },
                    { 49, "Muş" },
                    { 50, "Nevşehir" },
                    { 51, "Niğde" },
                    { 52, "Ordu" },
                    { 53, "Rize" },
                    { 54, "Sakarya" },
                    { 55, "Samsun" },
                    { 56, "Siirt" },
                    { 57, "Sinop" },
                    { 58, "Sivas" },
                    { 59, "Tekirdağ" },
                    { 60, "Tokat" },
                    { 61, "Trabzon" },
                    { 62, "Tunceli" },
                    { 63, "Şanlıurfa" },
                    { 64, "Uşak" },
                    { 65, "Van" },
                    { 66, "Yozgat" },
                    { 67, "Zonguldak" },
                    { 68, "Aksaray" },
                    { 69, "Bayburt" },
                    { 70, "Karaman" },
                    { 71, "Kırıkkale" },
                    { 72, "Batman" },
                    { 73, "Şırnak" },
                    { 74, "Bartın" },
                    { 75, "Ardahan" },
                    { 76, "Iğdır" },
                    { 77, "Yalova" },
                    { 78, "Karabük" },
                    { 79, "Kilis" },
                    { 80, "Osmaniye" },
                    { 81, "Düzce" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "ABANA", 37 },
                    { 2, "ACIPAYAM", 20 },
                    { 3, "ADALAR", 34 },
                    { 4, "SEYHAN", 1 },
                    { 5, "ADIYAMAN MERKEZ", 2 },
                    { 6, "ADİLCEVAZ", 13 },
                    { 7, "AFŞİN", 46 },
                    { 8, "AFYON MERKEZ", 3 },
                    { 9, "AĞLASUN", 15 },
                    { 10, "AĞIN", 23 },
                    { 11, "AĞRI MERKEZ", 4 },
                    { 12, "AHLAT", 13 },
                    { 13, "AKÇAABAT", 61 },
                    { 14, "AKÇADAĞ", 44 },
                    { 15, "AKÇAKALE", 63 },
                    { 16, "AKÇAKOCA", 81 },
                    { 17, "AKDAĞMADENİ", 66 },
                    { 18, "AKHİSAR", 45 },
                    { 19, "AKKUŞ", 52 },
                    { 20, "AKSARAY MERKEZ", 68 },
                    { 21, "AKSEKİ", 7 },
                    { 22, "AKŞEHİR", 42 },
                    { 23, "AKYAZI", 54 },
                    { 24, "ALACA", 19 },
                    { 25, "ALAÇAM", 55 },
                    { 26, "ALANYA", 7 },
                    { 27, "ALAŞEHİR", 45 },
                    { 28, "ALİAĞA", 35 },
                    { 29, "ALMUS", 60 },
                    { 30, "ALTINDAĞ", 6 },
                    { 31, "ALTINÖZÜ", 31 },
                    { 32, "ALTINTAŞ", 43 },
                    { 33, "ALUCRA", 28 },
                    { 34, "AMASYA MERKEZ", 5 },
                    { 35, "ANAMUR", 33 },
                    { 36, "ANDIRIN", 46 },
                    { 37, "ANKARA", 6 },
                    { 38, "ANTALYA MERKEZ", 7 },
                    { 39, "ARABAN", 27 },
                    { 40, "ARAÇ", 37 },
                    { 41, "ARAKLI", 61 },
                    { 42, "ARALIK", 76 },
                    { 43, "ARAPGİR", 44 },
                    { 44, "ARDAHAN MERKEZ", 75 },
                    { 45, "ARDANUÇ", 8 },
                    { 46, "ARDEŞEN", 53 },
                    { 47, "ARHAVİ", 8 },
                    { 48, "ARGUVAN", 44 },
                    { 49, "ARPAÇAY", 36 },
                    { 50, "ARSİN", 61 },
                    { 51, "ARTOVA", 60 },
                    { 52, "ARTVİN MERKEZ", 8 },
                    { 53, "AŞKALE", 25 },
                    { 54, "ATABEY", 32 },
                    { 55, "AVANOS", 50 },
                    { 56, "AYANCIK", 57 },
                    { 57, "AYAŞ", 6 },
                    { 58, "AYBASTI", 52 },
                    { 59, "AYDIN MERKEZ", 9 },
                    { 60, "AYVACIK", 17 },
                    { 61, "AYVALIK", 10 },
                    { 62, "AZDAVAY", 37 },
                    { 63, "BABAESKİ", 39 },
                    { 64, "BAFRA", 55 },
                    { 65, "BAHÇE", 80 },
                    { 66, "BAKIRKÖY", 34 },
                    { 67, "BALÂ", 6 },
                    { 68, "BALIKESİR MERKEZ", 10 },
                    { 69, "BALYA", 10 },
                    { 70, "BANAZ", 64 },
                    { 71, "BANDIRMA", 10 },
                    { 72, "BARTIN MERKEZ", 74 },
                    { 73, "BASKİL", 23 },
                    { 74, "BATMAN MERKEZ", 72 },
                    { 75, "BAŞKALE", 65 },
                    { 76, "BAYBURT MERKEZ", 69 },
                    { 77, "BAYAT", 19 },
                    { 78, "BAYINDIR", 35 },
                    { 79, "BAYKAN", 56 },
                    { 80, "BAYRAMİÇ", 17 },
                    { 81, "BERGAMA", 35 },
                    { 82, "BESNİ", 2 },
                    { 83, "BEŞİKTAŞ", 34 },
                    { 84, "BEŞİRİ", 72 },
                    { 85, "BEYKOZ", 34 },
                    { 86, "BEYOĞLU", 34 },
                    { 87, "BEYPAZARI", 6 },
                    { 88, "BEYŞEHİR", 42 },
                    { 89, "BEYTÜŞŞEBAP", 73 },
                    { 90, "BİGA", 17 },
                    { 91, "BİGADİÇ", 10 },
                    { 92, "BİLECİK MERKEZ", 11 },
                    { 93, "BİNGÖL MERKEZ", 12 },
                    { 94, "BİRECİK", 63 },
                    { 95, "BİSMİL", 21 },
                    { 96, "BİTLİS MERKEZ", 13 },
                    { 97, "BODRUM", 48 },
                    { 98, "BOĞAZLIYAN", 66 },
                    { 99, "BOLU MERKEZ", 14 },
                    { 100, "BOLVADİN", 3 },
                    { 101, "BOR", 51 },
                    { 102, "BORÇKA", 8 },
                    { 103, "BORNOVA", 35 },
                    { 104, "BOYABAT", 57 },
                    { 105, "BOZCAADA", 17 },
                    { 106, "BOZDOĞAN", 9 },
                    { 107, "BOZKIR", 42 },
                    { 108, "BOZKURT", 37 },
                    { 109, "BOZOVA", 63 },
                    { 110, "BOZÜYÜK", 11 },
                    { 111, "BUCAK", 15 },
                    { 112, "BULANCAK", 28 },
                    { 113, "BULANIK", 49 },
                    { 114, "BULDAN", 20 },
                    { 115, "BURDUR MERKEZ", 15 },
                    { 116, "BURHANİYE", 10 },
                    { 117, "BURSA MERKEZ", 16 },
                    { 118, "BÜNYAN", 38 },
                    { 119, "CEYHAN", 1 },
                    { 120, "CEYLANPINAR", 63 },
                    { 121, "CİDE", 37 },
                    { 122, "CİHANBEYLİ", 42 },
                    { 123, "CİZRE", 73 },
                    { 124, "ÇAL", 20 },
                    { 125, "ÇAMARDI", 51 },
                    { 126, "ÇAMELİ", 20 },
                    { 127, "ÇAMLIDERE", 6 },
                    { 128, "ÇAMLIHEMŞİN", 53 },
                    { 129, "ÇAN", 17 },
                    { 130, "ÇANAKKALE MERKEZ", 17 },
                    { 131, "ÇANKAYA", 6 },
                    { 132, "ÇANKIRI MERKEZ", 18 },
                    { 133, "ÇARDAK", 20 },
                    { 134, "ÇARŞAMBA", 55 },
                    { 135, "ÇAT", 25 },
                    { 136, "ÇATAK", 65 },
                    { 137, "ÇATALCA", 34 },
                    { 138, "ÇATALZEYTİN", 37 },
                    { 139, "ÇAY", 3 },
                    { 140, "ÇAYCUMA", 67 },
                    { 141, "ÇAYELİ", 53 },
                    { 142, "ÇAYIRALAN", 66 },
                    { 143, "ÇAYIRLI", 24 },
                    { 144, "ÇAYKARA", 61 },
                    { 145, "ÇEKEREK", 66 },
                    { 146, "ÇELİKHAN", 2 },
                    { 147, "ÇEMİŞGEZEK", 62 },
                    { 148, "ÇERKEŞ", 18 },
                    { 149, "ÇERMİK", 21 },
                    { 150, "ÇERKEZKÖY", 59 },
                    { 151, "ÇEŞME", 35 },
                    { 152, "ÇILDIR", 75 },
                    { 153, "ÇINAR", 21 },
                    { 154, "ÇİÇEKDAĞI", 40 },
                    { 155, "ÇİFTELER", 26 },
                    { 156, "ÇİNE", 9 },
                    { 157, "ÇİVRİL", 20 },
                    { 158, "ÇORLU", 59 },
                    { 159, "ÇORUM MERKEZ", 19 },
                    { 160, "ÇUBUK", 6 },
                    { 161, "ÇUKURCA", 30 },
                    { 162, "ÇUMRA", 42 },
                    { 163, "ÇÜNGÜŞ", 21 },
                    { 164, "DADAY", 37 },
                    { 165, "DARENDE", 44 },
                    { 166, "DATÇA", 48 },
                    { 167, "DAZKIRI", 3 },
                    { 168, "DELİCE", 71 },
                    { 169, "DEMİRCİ", 45 },
                    { 170, "DEMİRKÖY", 39 },
                    { 171, "DENİZLİ MERKEZ", 20 },
                    { 172, "DERELİ", 28 },
                    { 173, "DERİK", 47 },
                    { 174, "DERİNKUYU", 50 },
                    { 175, "DEVELİ", 38 },
                    { 176, "DEVREK", 67 },
                    { 177, "DEVREKÂNİ", 37 },
                    { 178, "DİCLE", 21 },
                    { 179, "DİGOR", 36 },
                    { 180, "DİKİLİ", 35 },
                    { 181, "DİNAR", 3 },
                    { 182, "DİVRİĞİ", 58 },
                    { 183, "DİYADİN", 4 },
                    { 184, "DİYARBAKIR MERKEZ", 21 },
                    { 185, "DOĞANHİSAR", 42 },
                    { 186, "DOĞANŞEHİR", 44 },
                    { 187, "DOĞUBAYAZIT", 4 },
                    { 188, "DOMANİÇ", 43 },
                    { 189, "DÖRTYOL", 31 },
                    { 190, "DURAĞAN", 57 },
                    { 191, "DURSUNBEY", 10 },
                    { 192, "DÜZCE MERKEZ", 81 },
                    { 193, "ECEABAT", 17 },
                    { 194, "EDREMİT", 10 },
                    { 195, "EDİRNE MERKEZ", 22 },
                    { 196, "EFLÂNİ", 78 },
                    { 197, "EĞİRDİR", 32 },
                    { 198, "ELAZIĞ MERKEZ", 23 },
                    { 199, "ELBİSTAN", 46 },
                    { 200, "ELDİVAN", 18 },
                    { 201, "ELEŞKİRT", 4 },
                    { 202, "ELMADAĞ", 6 },
                    { 203, "ELMALI", 7 },
                    { 204, "EMET", 43 },
                    { 205, "EMİNÖNÜ", 34 },
                    { 206, "EMİRDAĞ", 3 },
                    { 207, "ENEZ", 22 },
                    { 208, "ERBAA", 60 },
                    { 209, "ERCİŞ", 65 },
                    { 210, "ERDEK", 10 },
                    { 211, "ERDEMLİ", 33 },
                    { 212, "EREĞLİ", 42 },
                    { 213, "EREĞLİ", 67 },
                    { 214, "ERFELEK", 57 },
                    { 215, "ERGANİ", 21 },
                    { 216, "ERMENEK", 70 },
                    { 217, "ERUH", 56 },
                    { 218, "ERZİNCAN MERKEZ", 24 },
                    { 219, "ERZURUM MERKEZ", 25 },
                    { 220, "ESPİYE", 28 },
                    { 221, "ESKİPAZAR", 78 },
                    { 222, "ESKİŞEHİR MERKEZ", 26 },
                    { 223, "EŞME", 64 },
                    { 224, "EYNESİL", 28 },
                    { 225, "EYÜP", 34 },
                    { 226, "EZİNE", 17 },
                    { 227, "FATİH", 34 },
                    { 228, "FATSA", 52 },
                    { 229, "FEKE", 1 },
                    { 230, "FELAHİYE", 38 },
                    { 231, "FETHİYE", 48 },
                    { 232, "FINDIKLI", 53 },
                    { 233, "FİNİKE", 7 },
                    { 234, "FOÇA", 35 },
                    { 235, "GAZİANTEP MERKEZ", 27 },
                    { 236, "GAZİOSMANPAŞA", 34 },
                    { 237, "GAZİPAŞA", 7 },
                    { 238, "GEBZE", 41 },
                    { 239, "GEDİZ", 43 },
                    { 240, "GELİBOLU", 17 },
                    { 241, "GELENDOST", 32 },
                    { 242, "GEMEREK", 58 },
                    { 243, "GEMLİK", 16 },
                    { 244, "GENÇ", 12 },
                    { 245, "GERCÜŞ", 72 },
                    { 246, "GEREDE", 14 },
                    { 247, "GERGER", 2 },
                    { 248, "GERMENCİK", 9 },
                    { 249, "GERZE", 57 },
                    { 250, "GEVAŞ", 65 },
                    { 251, "GEYVE", 54 },
                    { 252, "GİRESUN MERKEZ", 28 },
                    { 253, "GÖKSUN", 46 },
                    { 254, "GÖLBAŞI", 2 },
                    { 255, "GÖLCÜK", 41 },
                    { 256, "GÖLE", 75 },
                    { 257, "GÖLHİSAR", 15 },
                    { 258, "GÖLKÖY", 52 },
                    { 259, "GÖLPAZARI", 11 },
                    { 260, "GÖNEN", 10 },
                    { 261, "GÖRELE", 28 },
                    { 262, "GÖRDES", 45 },
                    { 263, "GÖYNÜCEK", 5 },
                    { 264, "GÖYNÜK", 14 },
                    { 265, "GÜDÜL", 6 },
                    { 266, "GÜLNAR", 33 },
                    { 267, "GÜLŞEHİR", 50 },
                    { 268, "GÜMÜŞHACIKÖY", 5 },
                    { 269, "GÜMÜŞHANE MERKEZ", 29 },
                    { 270, "GÜNDOĞMUŞ", 7 },
                    { 271, "GÜNEY", 20 },
                    { 272, "GÜRPINAR", 65 },
                    { 273, "GÜRÜN", 58 },
                    { 274, "HACIBEKTAŞ", 50 },
                    { 275, "HADIM", 42 },
                    { 276, "HAFİK", 58 },
                    { 277, "HAKKARİ MERKEZ", 30 },
                    { 278, "HALFETİ", 63 },
                    { 279, "HAMUR", 4 },
                    { 280, "HANAK", 75 },
                    { 281, "HANİ", 21 },
                    { 282, "HASSA", 31 },
                    { 283, "HATAY MERKEZ", 31 },
                    { 284, "HAVRAN", 10 },
                    { 285, "HAVSA", 22 },
                    { 286, "HAVZA", 55 },
                    { 287, "HAYMANA", 6 },
                    { 288, "HAYRABOLU", 59 },
                    { 289, "HAZRO", 21 },
                    { 290, "HEKİMHAN", 44 },
                    { 291, "HENDEK", 54 },
                    { 292, "HINIS", 25 },
                    { 293, "HİLVAN", 63 },
                    { 294, "HİZAN", 13 },
                    { 295, "HOPA", 8 },
                    { 296, "HORASAN", 25 },
                    { 297, "HOZAT", 62 },
                    { 298, "IĞDIR MERKEZ", 76 },
                    { 299, "ILGAZ", 18 },
                    { 300, "ILGIN", 42 },
                    { 301, "ISPARTA MERKEZ", 32 },
                    { 302, "İÇEL MERKEZ", 33 },
                    { 303, "İDİL", 73 },
                    { 304, "İHSANİYE", 3 },
                    { 305, "İKİZDERE", 53 },
                    { 306, "İLİÇ", 24 },
                    { 307, "İMRANLI", 58 },
                    { 308, "GÖKÇEADA (İMROZ)", 17 },
                    { 309, "İNCESU", 38 },
                    { 310, "İNEBOLU", 37 },
                    { 311, "İNEGÖL", 16 },
                    { 312, "İPSALA", 22 },
                    { 313, "İSKENDERUN", 31 },
                    { 314, "İSKİLİP", 19 },
                    { 315, "İSLAHİYE", 27 },
                    { 316, "İSPİR", 25 },
                    { 317, "İSTANBUL MERKEZ", 34 },
                    { 318, "İVRİNDİ", 10 },
                    { 319, "İZMİR MERKEZ", 35 },
                    { 320, "İZNİK", 16 },
                    { 321, "KADIKÖY", 34 },
                    { 322, "KADINHANI", 42 },
                    { 323, "KADİRLİ", 80 },
                    { 324, "KAĞIZMAN", 36 },
                    { 325, "KAHTA", 2 },
                    { 326, "KALE", 20 },
                    { 327, "KALECİK", 6 },
                    { 328, "KALKANDERE", 53 },
                    { 329, "KAMAN", 40 },
                    { 330, "KANDIRA", 41 },
                    { 331, "KANGAL", 58 },
                    { 332, "KARABURUN", 35 },
                    { 333, "KARABÜK MERKEZ", 78 },
                    { 334, "KARACABEY", 16 },
                    { 335, "KARACASU", 9 },
                    { 336, "KARAHALLI", 64 },
                    { 337, "KARAİSALI", 1 },
                    { 338, "KARAKOÇAN", 23 },
                    { 339, "KARAMAN MERKEZ", 70 },
                    { 340, "KARAMÜRSEL", 41 },
                    { 341, "KARAPINAR", 42 },
                    { 342, "KARASU", 54 },
                    { 343, "KARATAŞ", 1 },
                    { 344, "KARAYAZI", 25 },
                    { 345, "KARGI", 19 },
                    { 346, "KARLIOVA", 12 },
                    { 347, "KARS MERKEZ", 36 },
                    { 348, "KARŞIYAKA", 35 },
                    { 349, "KARTAL", 34 },
                    { 350, "KASTAMONU MERKEZ", 37 },
                    { 351, "KAŞ", 7 },
                    { 352, "KAVAK", 55 },
                    { 353, "KAYNARCA", 54 },
                    { 354, "KAYSERİ MERKEZ", 38 },
                    { 355, "KEBAN", 23 },
                    { 356, "KEÇİBORLU", 32 },
                    { 357, "KELES", 16 },
                    { 358, "KELKİT", 29 },
                    { 359, "KEMAH", 24 },
                    { 360, "KEMALİYE", 24 },
                    { 361, "KEMALPAŞA", 35 },
                    { 362, "KEPSUT", 10 },
                    { 363, "KESKİN", 71 },
                    { 364, "KEŞAN", 22 },
                    { 365, "KEŞAP", 28 },
                    { 366, "KIBRISCIK", 14 },
                    { 367, "KINIK", 35 },
                    { 368, "KIRIKHAN", 31 },
                    { 369, "KIRIKKALE MERKEZ", 71 },
                    { 370, "KIRKAĞAÇ", 45 },
                    { 371, "KIRKLARELİ MERKEZ", 39 },
                    { 372, "KIRŞEHİR MERKEZ", 40 },
                    { 373, "KIZILCAHAMAM", 6 },
                    { 374, "KIZILTEPE", 47 },
                    { 375, "KİĞI", 12 },
                    { 376, "KİLİS MERKEZ", 79 },
                    { 377, "KİRAZ", 35 },
                    { 378, "KOCAELİ MERKEZ (İZMİT)", 41 },
                    { 379, "KOÇARLI", 9 },
                    { 380, "KOFÇAZ", 39 },
                    { 381, "KONYA MERKEZ", 42 },
                    { 382, "KORGAN", 52 },
                    { 383, "KORKUTELİ", 7 },
                    { 384, "KOYULHİSAR", 58 },
                    { 385, "KOZAKLI", 50 },
                    { 386, "KOZAN", 1 },
                    { 387, "KOZLUK", 72 },
                    { 388, "KÖYCEĞİZ", 48 },
                    { 389, "KULA", 45 },
                    { 390, "KULP", 21 },
                    { 391, "KULU", 42 },
                    { 392, "KUMLUCA", 7 },
                    { 393, "KUMRU", 52 },
                    { 394, "KURŞUNLU", 18 },
                    { 395, "KURTALAN", 56 },
                    { 396, "KURUCAŞİLE", 74 },
                    { 397, "KUŞADASI", 9 },
                    { 398, "KUYUCAK", 9 },
                    { 399, "KÜRE", 37 },
                    { 400, "KÜTAHYA MERKEZ", 43 },
                    { 401, "LADİK", 55 },
                    { 402, "LALAPAŞA", 22 },
                    { 403, "LAPSEKİ", 17 },
                    { 404, "LİCE", 21 },
                    { 405, "LÜLEBURGAZ", 39 },
                    { 406, "MADEN", 23 },
                    { 407, "MAÇKA", 61 },
                    { 408, "MAHMUDİYE", 26 },
                    { 409, "MALATYA MERKEZ", 44 },
                    { 410, "MALAZGİRT", 49 },
                    { 411, "MALKARA", 59 },
                    { 412, "MANAVGAT", 7 },
                    { 413, "MANİSA MERKEZ", 45 },
                    { 414, "MANYAS", 10 },
                    { 415, "KAHRAMANMARAŞ MERKEZ", 46 },
                    { 416, "MARDİN MERKEZ", 47 },
                    { 417, "MARMARİS", 48 },
                    { 418, "MAZGİRT", 62 },
                    { 419, "MAZIDAĞI", 47 },
                    { 420, "MECİTÖZÜ", 19 },
                    { 421, "MENEMEN", 35 },
                    { 422, "MENGEN", 14 },
                    { 423, "MERİÇ", 22 },
                    { 424, "MERZİFON", 5 },
                    { 425, "MESUDİYE", 52 },
                    { 426, "MİDYAT", 47 },
                    { 427, "MİHALIÇÇIK", 26 },
                    { 428, "MİLAS", 48 },
                    { 429, "MUCUR", 40 },
                    { 430, "MUDANYA", 16 },
                    { 431, "MUDURNU", 14 },
                    { 432, "MUĞLA MERKEZ", 48 },
                    { 433, "MURADİYE", 65 },
                    { 434, "MUŞ MERKEZ", 49 },
                    { 435, "MUSTAFA KEMAL PAŞA", 16 },
                    { 436, "MUT", 33 },
                    { 437, "MUTKİ", 13 },
                    { 438, "MURATLI", 59 },
                    { 439, "NALLIHAN", 6 },
                    { 440, "NARMAN", 25 },
                    { 441, "NAZIMİYE", 62 },
                    { 442, "NAZİLLİ", 9 },
                    { 443, "NEVŞEHİR MERKEZ", 50 },
                    { 444, "NİĞDE MERKEZ", 51 },
                    { 445, "NİKSAR", 60 },
                    { 446, "NİZİP", 27 },
                    { 447, "NUSAYBİN", 47 },
                    { 448, "OF", 61 },
                    { 449, "OĞUZELİ", 27 },
                    { 450, "OLTU", 25 },
                    { 451, "OLUR", 25 },
                    { 452, "ORDU MERKEZ", 52 },
                    { 453, "ORHANELİ", 16 },
                    { 454, "ORHANGAZİ", 16 },
                    { 455, "ORTA", 18 },
                    { 456, "ORTAKÖY", 19 },
                    { 457, "ORTAKÖY", 68 },
                    { 458, "OSMANCIK", 19 },
                    { 459, "OSMANELİ", 11 },
                    { 460, "OSMANİYE MERKEZ", 80 },
                    { 461, "OVACIK", 78 },
                    { 462, "OVACIK", 62 },
                    { 463, "ÖDEMİŞ", 35 },
                    { 464, "ÖMERLİ", 47 },
                    { 465, "ÖZALP", 65 },
                    { 466, "PALU", 23 },
                    { 467, "PASİNLER", 25 },
                    { 468, "PATNOS", 4 },
                    { 469, "PAZAR", 53 },
                    { 470, "PAZARCIK", 46 },
                    { 471, "PAZARYERİ", 11 },
                    { 472, "PEHLİVANKÖY", 39 },
                    { 473, "PERŞEMBE", 52 },
                    { 474, "PERTEK", 62 },
                    { 475, "PERVARİ", 56 },
                    { 476, "PINARBAŞI", 38 },
                    { 477, "PINARHİSAR", 39 },
                    { 478, "POLATLI", 6 },
                    { 479, "POSOF", 75 },
                    { 480, "POZANTI", 1 },
                    { 481, "PÜLÜMÜR", 62 },
                    { 482, "PÜTÜRGE", 44 },
                    { 483, "REFAHİYE", 24 },
                    { 484, "REŞADİYE", 60 },
                    { 485, "REYHANLI", 31 },
                    { 486, "RİZE MERKEZ", 53 },
                    { 487, "SAFRANBOLU", 78 },
                    { 488, "SAİMBEYLİ", 1 },
                    { 489, "SAKARYA MERKEZ (ADAPAZARI)", 54 },
                    { 490, "SALİHLİ", 45 },
                    { 491, "SAMANDAĞ", 31 },
                    { 492, "SAMSAT", 2 },
                    { 493, "SAMSUN MERKEZ", 55 },
                    { 494, "SANDIKLI", 3 },
                    { 495, "SAPANCA", 54 },
                    { 496, "SARAY", 59 },
                    { 497, "SARAYKÖY", 20 },
                    { 498, "SARAYÖNÜ", 42 },
                    { 499, "SARICAKAYA", 26 },
                    { 500, "SARIGÖL", 45 },
                    { 501, "SARIKAMIŞ", 36 },
                    { 502, "SARIKAYA", 66 },
                    { 503, "SARIOĞLAN", 38 },
                    { 504, "SARIYER", 34 },
                    { 505, "SARIZ", 38 },
                    { 506, "SARUHANLI", 45 },
                    { 507, "SASON", 72 },
                    { 508, "SAVAŞTEPE", 10 },
                    { 509, "SAVUR", 47 },
                    { 510, "SEBEN", 14 },
                    { 511, "SEFERİHİSAR", 35 },
                    { 512, "SELÇUK", 35 },
                    { 513, "SELENDİ", 45 },
                    { 514, "SELİM", 36 },
                    { 515, "SENİRKENT", 32 },
                    { 516, "SERİK", 7 },
                    { 517, "SEYDİŞEHİR", 42 },
                    { 518, "SEYİTGAZİ", 26 },
                    { 519, "SINDIRGI", 10 },
                    { 520, "SİİRT MERKEZ", 56 },
                    { 521, "SİLİFKE", 33 },
                    { 522, "SİLİVRİ", 34 },
                    { 523, "SİLOPİ", 73 },
                    { 524, "SİLVAN", 21 },
                    { 525, "SİMAV", 43 },
                    { 526, "SİNCANLI", 3 },
                    { 527, "SİNOP MERKEZ", 57 },
                    { 528, "SİVAS MERKEZ", 58 },
                    { 529, "SİVASLI", 64 },
                    { 530, "SİVEREK", 63 },
                    { 531, "SİVRİCE", 23 },
                    { 532, "SİVRİHİSAR", 26 },
                    { 533, "SOLHAN", 12 },
                    { 534, "SOMA", 45 },
                    { 535, "SORGUN", 66 },
                    { 536, "SÖĞÜT", 11 },
                    { 537, "SÖKE", 9 },
                    { 538, "SULAKYURT", 71 },
                    { 539, "SULTANDAĞI", 3 },
                    { 540, "SULTANHİSAR", 9 },
                    { 541, "SULUOVA", 5 },
                    { 542, "SUNGURLU", 19 },
                    { 543, "SURUÇ", 63 },
                    { 544, "SUSURLUK", 10 },
                    { 545, "SUSUZ", 36 },
                    { 546, "SUŞEHRİ", 58 },
                    { 547, "SÜRMENE", 61 },
                    { 548, "SÜTÇÜLER", 32 },
                    { 549, "ŞABANÖZÜ", 18 },
                    { 550, "ŞARKIŞLA", 58 },
                    { 551, "ŞARKİKARAAĞAÇ", 32 },
                    { 552, "ŞARKÖY", 59 },
                    { 553, "ŞAVŞAT", 8 },
                    { 554, "ŞEBİNKARAHİSAR", 28 },
                    { 555, "ŞEFAATLİ", 66 },
                    { 556, "ŞEMDİNLİ", 30 },
                    { 557, "ŞENKAYA", 25 },
                    { 558, "ŞEREFLİKOÇHİSAR", 6 },
                    { 559, "ŞİLE", 34 },
                    { 560, "ŞİRAN", 29 },
                    { 561, "ŞIRNAK MERKEZ", 73 },
                    { 562, "ŞİRVAN", 56 },
                    { 563, "ŞİŞLİ", 34 },
                    { 564, "ŞUHUT", 3 },
                    { 565, "TARSUS", 33 },
                    { 566, "TAŞKÖPRÜ", 37 },
                    { 567, "TAŞLIÇAY", 4 },
                    { 568, "TAŞOVA", 5 },
                    { 569, "TATVAN", 13 },
                    { 570, "TAVAS", 20 },
                    { 571, "TAVŞANLI", 43 },
                    { 572, "TEFENNİ", 15 },
                    { 573, "TEKİRDAĞ MERKEZ", 59 },
                    { 574, "TEKMAN", 25 },
                    { 575, "TERCAN", 24 },
                    { 576, "TERME", 55 },
                    { 577, "TİRE", 35 },
                    { 578, "TİREBOLU", 28 },
                    { 579, "TOKAT MERKEZ", 60 },
                    { 580, "TOMARZA", 38 },
                    { 581, "TONYA", 61 },
                    { 582, "TORBALI", 35 },
                    { 583, "TORTUM", 25 },
                    { 584, "TORUL", 29 },
                    { 585, "TOSYA", 37 },
                    { 586, "TRABZON MERKEZ", 61 },
                    { 587, "TUFANBEYLİ", 1 },
                    { 588, "TUNCELİ MERKEZ", 62 },
                    { 589, "TURGUTLU", 45 },
                    { 590, "TURHAL", 60 },
                    { 591, "TUTAK", 4 },
                    { 592, "TUZLUCA", 76 },
                    { 593, "TÜRKELİ", 57 },
                    { 594, "TÜRKOĞLU", 46 },
                    { 595, "ULA", 48 },
                    { 596, "ULUBEY", 52 },
                    { 597, "ULUBEY", 64 },
                    { 598, "ULUDERE", 73 },
                    { 599, "ULUBORLU", 32 },
                    { 600, "ULUKIŞLA", 51 },
                    { 601, "ULUS", 74 },
                    { 602, "ŞANLIURFA MERKEZ", 63 },
                    { 603, "URLA", 35 },
                    { 604, "UŞAK MERKEZ", 64 },
                    { 605, "UZUNKÖPRÜ", 22 },
                    { 606, "ÜNYE", 52 },
                    { 607, "ÜRGÜP", 50 },
                    { 608, "ÜSKÜDAR", 34 },
                    { 609, "VAKFIKEBİR", 61 },
                    { 610, "VAN MERKEZ", 65 },
                    { 611, "VARTO", 49 },
                    { 612, "VEZİRKÖPRÜ", 55 },
                    { 613, "VİRANŞEHİR", 63 },
                    { 614, "VİZE", 39 },
                    { 615, "YAHYALI", 38 },
                    { 616, "YALOVA MERKEZ", 77 },
                    { 617, "YALVAÇ", 32 },
                    { 618, "YAPRAKLI", 18 },
                    { 619, "YATAĞAN", 48 },
                    { 620, "YAVUZELİ", 27 },
                    { 621, "YAYLADAĞI", 31 },
                    { 622, "YENİCE", 17 },
                    { 623, "YENİMAHALLE", 6 },
                    { 624, "YENİPAZAR", 9 },
                    { 625, "YENİŞEHİR", 16 },
                    { 626, "YERKÖY", 66 },
                    { 627, "YEŞİLHİSAR", 38 },
                    { 628, "YEŞİLOVA", 15 },
                    { 629, "YEŞİLYURT", 44 },
                    { 630, "YIĞILCA", 81 },
                    { 631, "YILDIZELİ", 58 },
                    { 632, "YOMRA", 61 },
                    { 633, "YOZGAT MERKEZ", 66 },
                    { 634, "YUMURTALIK", 1 },
                    { 635, "YUNAK", 42 },
                    { 636, "YUSUFELİ", 8 },
                    { 637, "YÜKSEKOVA", 30 },
                    { 638, "ZARA", 58 },
                    { 639, "ZEYTİNBURNU", 34 },
                    { 640, "ZİLE", 60 },
                    { 641, "ZONGULDAK MERKEZ", 67 },
                    { 642, "DALAMAN", 48 },
                    { 643, "DÜZİÇİ", 80 },
                    { 644, "GÖLBAŞI", 6 },
                    { 645, "KEÇİÖREN", 6 },
                    { 646, "MAMAK", 6 },
                    { 647, "SİNCAN", 6 },
                    { 648, "YÜREĞİR", 1 },
                    { 649, "ACIGÖL", 50 },
                    { 650, "ADAKLI", 12 },
                    { 651, "AHMETLİ", 45 },
                    { 652, "AKKIŞLA", 38 },
                    { 653, "AKÖREN", 42 },
                    { 654, "AKPINAR", 40 },
                    { 655, "AKSU", 32 },
                    { 656, "AKYAKA", 36 },
                    { 657, "ALADAĞ", 1 },
                    { 658, "ALAPLI", 67 },
                    { 659, "ALPU", 26 },
                    { 660, "ALTINEKİN", 42 },
                    { 661, "AMASRA", 74 },
                    { 662, "ARICAK", 23 },
                    { 663, "ASARCIK", 55 },
                    { 664, "ASLANAPA", 43 },
                    { 665, "ATKARACALAR", 18 },
                    { 666, "AYDINCIK", 33 },
                    { 667, "AYDINTEPE", 69 },
                    { 668, "AYRANCI", 70 },
                    { 669, "BABADAĞ", 20 },
                    { 670, "BAHÇESARAY", 65 },
                    { 671, "BAŞMAKÇI", 3 },
                    { 672, "BATTALGAZİ", 44 },
                    { 673, "BAYAT", 3 },
                    { 674, "BEKİLLİ", 20 },
                    { 675, "BEŞİKDÜZÜ", 61 },
                    { 676, "BEYDAĞ", 35 },
                    { 677, "BEYLİKOVA", 26 },
                    { 678, "BOĞAZKALE", 19 },
                    { 679, "BOZYAZI", 33 },
                    { 680, "BUCA", 35 },
                    { 681, "BUHARKENT", 9 },
                    { 682, "BÜYÜKÇEKMECE", 34 },
                    { 683, "BÜYÜKORHAN", 16 },
                    { 684, "CUMAYERİ", 81 },
                    { 685, "ÇAĞLIYANCERİT", 46 },
                    { 686, "ÇALDIRAN", 65 },
                    { 687, "DARGEÇİT", 47 },
                    { 688, "DEMİRÖZÜ", 69 },
                    { 689, "DEREBUCAK", 42 },
                    { 690, "DUMLUPINAR", 43 },
                    { 691, "EĞİL", 21 },
                    { 692, "ERZİN", 31 },
                    { 693, "GÖLMARMARA", 45 },
                    { 694, "GÖLYAKA", 81 },
                    { 695, "GÜLYALI", 52 },
                    { 696, "GÜNEYSU", 53 },
                    { 697, "GÜRGENTEPE", 52 },
                    { 698, "GÜROYMAK", 13 },
                    { 699, "HARMANCIK", 16 },
                    { 700, "HARRAN", 63 },
                    { 701, "HASKÖY", 49 },
                    { 702, "HİSARCIK", 43 },
                    { 703, "HONAZ", 20 },
                    { 704, "HÜYÜK", 42 },
                    { 705, "İHSANGAZİ", 37 },
                    { 706, "İMAMOĞLU", 1 },
                    { 707, "İNCİRLİOVA", 9 },
                    { 708, "İNÖNÜ", 26 },
                    { 709, "İSCEHİSAR", 3 },
                    { 710, "KAĞITHANE", 34 },
                    { 711, "KALE", 7 },
                    { 712, "KARAÇOBAN", 25 },
                    { 713, "KARAMANLI", 15 },
                    { 714, "KARATAY", 42 },
                    { 715, "KAZAN", 6 },
                    { 716, "KEMER", 15 },
                    { 717, "KIZILIRMAK", 18 },
                    { 718, "KOCAALİ", 54 },
                    { 719, "KONAK", 35 },
                    { 720, "KOVANCILAR", 23 },
                    { 721, "KÖRFEZ", 41 },
                    { 722, "KÖSE", 29 },
                    { 723, "KÜÇÜKÇEKMECE", 34 },
                    { 724, "MARMARA", 10 },
                    { 725, "MARMARAEREĞLİSİ", 59 },
                    { 726, "MENDERES", 35 },
                    { 727, "MERAM", 42 },
                    { 728, "MURGUL", 8 },
                    { 729, "NİLÜFER", 16 },
                    { 730, "ONDOKUZMAYIS", 55 },
                    { 731, "ORTACA", 48 },
                    { 732, "OSMANGAZİ", 16 },
                    { 733, "PAMUKOVA", 54 },
                    { 734, "PAZAR", 60 },
                    { 735, "PENDİK", 34 },
                    { 736, "PINARBAŞI", 37 },
                    { 737, "PİRAZİZ", 28 },
                    { 738, "SALIPAZARI", 55 },
                    { 739, "SELÇUKLU", 42 },
                    { 740, "SERİNHİSAR", 20 },
                    { 741, "ŞAHİNBEY", 27 },
                    { 742, "ŞALPAZARI", 61 },
                    { 743, "ŞAPHANE", 43 },
                    { 744, "ŞEHİTKAMİL", 27 },
                    { 745, "ŞENPAZAR", 37 },
                    { 746, "TALAS", 38 },
                    { 747, "TARAKLI", 54 },
                    { 748, "TAŞKENT", 42 },
                    { 749, "TEKKEKÖY", 55 },
                    { 750, "UĞURLUDAĞ", 19 },
                    { 751, "UZUNDERE", 25 },
                    { 752, "ÜMRANİYE", 34 },
                    { 753, "ÜZÜMLÜ", 24 },
                    { 754, "YAĞLIDERE", 28 },
                    { 755, "YAYLADERE", 12 },
                    { 756, "YENİCE", 78 },
                    { 757, "YENİPAZAR", 11 },
                    { 758, "YEŞİLYURT", 60 },
                    { 759, "YILDIRIM", 16 },
                    { 760, "AĞAÇÖREN", 68 },
                    { 761, "GÜZELYURT", 68 },
                    { 762, "KÂZIMKARABEKİR", 70 },
                    { 763, "KOCASİNAN", 38 },
                    { 764, "MELİKGAZİ", 38 },
                    { 765, "PAZARYOLU", 25 },
                    { 766, "SARIYAHŞİ", 68 },
                    { 767, "AĞLI", 37 },
                    { 768, "AHIRLI", 42 },
                    { 769, "AKÇAKENT", 40 },
                    { 770, "AKINCILAR", 58 },
                    { 771, "AKKÖY", 20 },
                    { 772, "AKYURT", 6 },
                    { 773, "ALACAKAYA", 23 },
                    { 774, "ALTINYAYLA", 15 },
                    { 775, "ALTINYAYLA", 58 },
                    { 776, "ALTUNHİSAR", 51 },
                    { 777, "AYDINCIK", 66 },
                    { 778, "AYDINLAR", 56 },
                    { 779, "AYVACIK", 55 },
                    { 780, "BAHŞİLİ", 71 },
                    { 781, "BAKLAN", 20 },
                    { 782, "BALIŞEYH", 71 },
                    { 783, "BAŞÇİFTLİK", 60 },
                    { 784, "BAŞYAYLA", 70 },
                    { 785, "BAYRAMÖREN", 18 },
                    { 786, "BAYRAMPAŞA", 34 },
                    { 787, "BELEN", 31 },
                    { 788, "BEYAĞAÇ", 20 },
                    { 789, "BOZKURT", 20 },
                    { 790, "BOZTEPE", 40 },
                    { 791, "ÇAMAŞ", 52 },
                    { 792, "ÇAMLIYAYLA", 33 },
                    { 793, "ÇAMOLUK", 28 },
                    { 794, "ÇANAKÇI", 28 },
                    { 795, "ÇANDIR", 66 },
                    { 796, "ÇARŞIBAŞI", 61 },
                    { 797, "ÇATALPINAR", 52 },
                    { 798, "ÇAVDARHİSAR", 43 },
                    { 799, "ÇAVDIR", 15 },
                    { 800, "ÇAYBAŞI", 52 },
                    { 801, "ÇELEBİ", 71 },
                    { 802, "ÇELTİK", 42 },
                    { 803, "ÇELTİKÇİ", 15 },
                    { 804, "ÇİFTLİK", 51 },
                    { 805, "ÇİLİMLİ", 81 },
                    { 806, "ÇOBANLAR", 3 },
                    { 807, "DERBENT", 42 },
                    { 808, "DEREPAZARI", 53 },
                    { 809, "DERNEKPAZARI", 61 },
                    { 810, "DİKMEN", 57 },
                    { 811, "DODURGA", 19 },
                    { 812, "DOĞANKENT", 28 },
                    { 813, "DOĞANŞAR", 58 },
                    { 814, "DOĞANYOL", 44 },
                    { 815, "DOĞANYURT", 37 },
                    { 816, "DÖRTDİVAN", 14 },
                    { 817, "DÜZKÖY", 61 },
                    { 818, "EDREMİT", 65 },
                    { 819, "EKİNÖZÜ", 46 },
                    { 820, "EMİRGAZİ", 42 },
                    { 821, "ESKİL", 68 },
                    { 822, "ETİMESGUT", 6 },
                    { 823, "EVCİLER", 3 },
                    { 824, "EVREN", 6 },
                    { 825, "FERİZLİ", 54 },
                    { 826, "GÖKÇEBEY", 67 },
                    { 827, "GÖLOVA", 58 },
                    { 828, "GÖMEÇ", 10 },
                    { 829, "GÖNEN", 32 },
                    { 830, "GÜCE", 28 },
                    { 831, "GÜÇLÜKONAK", 73 },
                    { 832, "GÜLAĞAÇ", 68 },
                    { 833, "GÜNEYSINIR", 42 },
                    { 834, "GÜNYÜZÜ", 26 },
                    { 835, "GÜRSU", 16 },
                    { 836, "HACILAR", 38 },
                    { 837, "HALKAPINAR", 42 },
                    { 838, "HAMAMÖZÜ", 5 },
                    { 839, "HAN", 26 },
                    { 840, "HANÖNÜ", 37 },
                    { 841, "HASANKEYF", 72 },
                    { 842, "HAYRAT", 61 },
                    { 843, "HEMŞİN", 53 },
                    { 844, "HOCALAR", 3 },
                    { 845, "ILICA", 25 },
                    { 846, "İBRADI", 7 },
                    { 847, "İKİZCE", 52 },
                    { 848, "İNHİSAR", 11 },
                    { 849, "İYİDERE", 53 },
                    { 850, "KABADÜZ", 52 },
                    { 851, "KABATAŞ", 52 },
                    { 852, "KADIŞEHRİ", 66 },
                    { 853, "KALE", 44 },
                    { 854, "KARAKEÇİLİ", 71 },
                    { 855, "KARAPÜRÇEK", 54 },
                    { 856, "KARKAMIŞ", 27 },
                    { 857, "KARPUZLU", 9 },
                    { 858, "KAVAKLIDERE", 48 },
                    { 859, "KEMER", 7 },
                    { 860, "KESTEL", 16 },
                    { 861, "KIZILÖREN", 3 },
                    { 862, "KOCAKÖY", 21 },
                    { 863, "KORGUN", 18 },
                    { 864, "KORKUT", 49 },
                    { 865, "KÖPRÜBAŞI", 45 },
                    { 866, "KÖPRÜBAŞI", 61 },
                    { 867, "KÖPRÜKÖY", 25 },
                    { 868, "KÖŞK", 9 },
                    { 869, "KULUNCAK", 44 },
                    { 870, "KUMLU", 31 },
                    { 871, "KÜRTÜN", 29 },
                    { 872, "LAÇİN", 19 },
                    { 873, "MİHALGAZİ", 26 },
                    { 874, "NURDAĞI", 27 },
                    { 875, "NURHAK", 46 },
                    { 876, "OĞUZLAR", 19 },
                    { 877, "OTLUKBELİ", 24 },
                    { 878, "ÖZVATAN", 38 },
                    { 879, "PAZARLAR", 43 },
                    { 880, "SARAY", 65 },
                    { 881, "SARAYDÜZÜ", 57 },
                    { 882, "SARAYKENT", 66 },
                    { 883, "SARIVELİLER", 70 },
                    { 884, "SEYDİLER", 37 },
                    { 885, "SİNCİK", 2 },
                    { 886, "SÖĞÜTLÜ", 54 },
                    { 887, "SULUSARAY", 60 },
                    { 888, "SÜLOĞLU", 22 },
                    { 889, "TUT", 2 },
                    { 890, "TUZLUKÇU", 42 },
                    { 891, "ULAŞ", 58 },
                    { 892, "YAHŞİHAN", 71 },
                    { 893, "YAKAKENT", 55 },
                    { 894, "YALIHÜYÜK", 42 },
                    { 895, "YAZIHAN", 44 },
                    { 896, "YEDİSU", 12 },
                    { 897, "YENİÇAĞA", 14 },
                    { 898, "YENİFAKILI", 66 },
                    { 899, "DİDİM (YENİHİSAR)", 9 },
                    { 900, "YENİŞARBADEMLİ", 32 },
                    { 901, "YEŞİLLİ", 47 },
                    { 902, "AVCILAR", 34 },
                    { 903, "BAĞCILAR", 34 },
                    { 904, "BAHÇELİEVLER", 34 },
                    { 905, "BALÇOVA", 35 },
                    { 906, "ÇİĞLİ", 35 },
                    { 907, "DAMAL", 75 },
                    { 908, "GAZİEMİR", 35 },
                    { 909, "GÜNGÖREN", 34 },
                    { 910, "KARAKOYUNLU", 76 },
                    { 911, "MALTEPE", 34 },
                    { 912, "NARLIDERE", 35 },
                    { 913, "SULTANBEYLİ", 34 },
                    { 914, "TUZLA", 34 },
                    { 915, "ESENLER", 34 },
                    { 916, "GÜMÜŞOVA", 81 },
                    { 917, "GÜZELBAHÇE", 35 },
                    { 918, "ALTINOVA", 77 },
                    { 919, "ARMUTLU", 77 },
                    { 920, "ÇINARCIK", 77 },
                    { 921, "ÇİFTLİKKÖY", 77 },
                    { 922, "ELBEYLİ", 79 },
                    { 923, "MUSABEYLİ", 79 },
                    { 924, "POLATELİ", 79 },
                    { 925, "TERMAL", 77 },
                    { 926, "HASANBEYLİ", 80 },
                    { 927, "SUMBAS", 80 },
                    { 928, "TOPRAKKALE", 80 },
                    { 929, "DERİNCE", 41 },
                    { 930, "KAYNAŞLI", 81 },
                    { 931, "SARIÇAM", 1 },
                    { 932, "ÇUKUROVA", 1 },
                    { 933, "PURSAKLAR", 6 },
                    { 934, "AKSU/ANTALYA", 7 },
                    { 935, "DÖŞEMEALTI", 7 },
                    { 936, "KEPEZ", 7 },
                    { 937, "KONYAALTI", 7 },
                    { 938, "MURATPAŞA", 7 },
                    { 939, "BAĞLAR", 21 },
                    { 940, "KAYAPINAR", 21 },
                    { 941, "SUR", 21 },
                    { 942, "YENİŞEHİR/DİYARBAKIR", 21 },
                    { 943, "PALANDÖKEN", 25 },
                    { 944, "YAKUTİYE", 25 },
                    { 945, "ODUNPAZARI", 26 },
                    { 946, "TEPEBAŞI", 26 },
                    { 947, "ARNAVUTKÖY", 34 },
                    { 948, "ATAŞEHİR", 34 },
                    { 949, "BAŞAKŞEHİR", 34 },
                    { 950, "BEYLİKDÜZÜ", 34 },
                    { 951, "ÇEKMEKÖY", 34 },
                    { 952, "ESENYURT", 34 },
                    { 953, "SANCAKTEPE", 34 },
                    { 954, "SULTANGAZİ", 34 },
                    { 955, "BAYRAKLI", 35 },
                    { 956, "KARABAĞLAR", 35 },
                    { 957, "BAŞİSKELE", 41 },
                    { 958, "ÇAYIROVA", 41 },
                    { 959, "DARICA ", 41 },
                    { 960, "DİLOVASI", 41 },
                    { 961, "İZMİT", 41 },
                    { 962, "KARTEPE", 41 },
                    { 963, "AKDENİZ", 33 },
                    { 964, "MEZİTLİ", 33 },
                    { 965, "TOROSLAR", 33 },
                    { 966, "YENİŞEHİR/MERSİN", 33 },
                    { 967, "ADAPAZARI", 54 },
                    { 968, "ARİFİYE", 54 },
                    { 969, "ERENLER", 54 },
                    { 970, "SERDİVAN", 54 },
                    { 971, "ATAKUM", 55 },
                    { 972, "CANİK", 55 },
                    { 973, "İLKADIM", 55 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserId",
                table: "Brands",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselImages_UserId",
                table: "CarouselImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogProduct_ProductsId",
                table: "CatalogProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_UserId",
                table: "Catalogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name_ProvinceId",
                table: "Cities",
                columns: new[] { "Name", "ProvinceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_UserId",
                table: "ProductImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_Name",
                table: "Provinces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CategoryId",
                table: "Specifications",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_UserId",
                table: "Specifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarouselImages");

            migrationBuilder.DropTable(
                name: "CatalogProduct");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "_EntityBase");
        }
    }
}
