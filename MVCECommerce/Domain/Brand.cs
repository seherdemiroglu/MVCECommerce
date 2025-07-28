using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCECommerce.Domain
{
    public class Brand : _EntityBase
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string? Name { get; set; }

        [Display(Name = "Logo")]
        public byte[]? Logo { get; set; }

        [NotMapped]
        public IFormFile? LogoFile { get; set; }//bunun db de karşılığı yok,kullanıcıdan bu fomatta alıcaz, byte a çevirip dbye koycaz
        public ICollection<Product> Products { get; set; } = new List<Product>();


    }

    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasIndex(p=> new { p.Name }); //builder.HasIndex(p => p.Name); de olur ama iki parametreli olsaydı bu kullanılamazdı.

            builder.Property(p => p.Name).IsRequired();

            builder.HasMany(p => p.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
