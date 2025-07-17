using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Domain
{
    public class ProductSpecification
    {
        public Guid ProductId { get; set; }
        public Guid SpecificationId { get; set; }
        public string? Value { get; set; }

    }

    public class ProductSpecificationsConfiguration : IEntityTypeConfiguration<ProductSpecification>
    {
        public void Configure(EntityTypeBuilder<ProductSpecification> builder)
        {
            builder.ToTable("ProductSpecifications");
            builder
                .HasKey(p => new { p.ProductId, p.SpecificationId });
            builder.Property(p => p.Value).IsRequired();


        }
    }
}
