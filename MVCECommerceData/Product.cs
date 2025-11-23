using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MVCECommerceData;

public class Product : _EntityBase
{
    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public Guid CategoryId { get; set; }

    [Display(Name = "Marka")]
    public Guid? BrandId { get; set; }

    [Display(Name = "Ad (Tr)")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public string? NameTr { get; set; }

    [Display(Name = "Ad (En)")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public string? NameEn { get; set; }

    [Display(Name = "Özellikler (Tr)")]
    public string? DescriptionTr { get; set; }

    [Display(Name = "Özellikler (En)")]
    public string? DescriptionEn { get; set; }

    [Display(Name = "Fiyat")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
    public decimal Price { get; set; }
    public byte[]? Image { get; set; }
    public int Views { get; set; }


    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    [NotMapped]
    public IFormFile[]? ImageFiles { get; set; }

    [NotMapped]
    [Display(Name = "Katalog")]
    public Guid[]? SelectedCatalogs { get; set; }

    public Brand? Brand { get; set; }
    public Category? Category { get; set; }
    public ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public ICollection<ProductSpecification> Specs { get; set; } = new List<ProductSpecification>();


}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder
        .HasIndex(p => new { p.NameTr });

        builder
            .HasIndex(p => new { p.NameEn });
        builder.Property(p => p.NameTr).IsRequired();
        builder.Property(p => p.NameEn).IsRequired();

        builder.Property(p => p.Price).HasPrecision(18, 4);

        builder.HasMany(p => p.Comments).WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.OrderItems).WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.ProductImages).WithOne(p => p.Product)
          .HasForeignKey(p => p.ProductId)
          .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.ShoppingCartItems).WithOne(p => p.Product)
          .HasForeignKey(p => p.ProductId)
          .OnDelete(DeleteBehavior.Restrict);

        builder
        .HasMany(p => p.Specs)
        .WithOne(p => p.Product)
        .HasForeignKey(p => p.ProductId)
        .OnDelete(DeleteBehavior.Cascade);

    }
}
