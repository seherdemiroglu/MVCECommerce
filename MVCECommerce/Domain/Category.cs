using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerce.Domain
{
    public class Category : _EntityBase
    {
        [Display(Name = "Ad (Tr)")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string? NameTr { get; set; }

        [Display(Name = "Ad (En)")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string? NameEn { get; set; }
        public byte[]? Image { get; set; } //kategoriye image ekle

        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Specification> Specifications { get; set; } = new List<Specification>();
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder
            .HasIndex(p => new { p.NameTr });

            builder
                .HasIndex(p => new { p.NameEn });

            builder.Property(p => p.NameTr).IsRequired();
            builder.Property(p => p.NameEn).IsRequired();

            builder
            .HasMany(p => p.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Specifications)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
