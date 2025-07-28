using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerce.Domain
{
    public class Catalog : _EntityBase
    {
        public string? NameTr { get; set; }
        public string? NameEn { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();//mant to many bağlantı (catalog listesi de product da var)

    }

    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("Catalogs");
            builder.HasIndex(p => new { p.NameTr });
            builder.HasIndex(p => new{p.NameEn});
            builder.Property(p => p.NameTr).IsRequired();
            builder.Property(p => p.NameEn).IsRequired();
        }
    }
}
