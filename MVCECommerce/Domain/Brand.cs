using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerce.Domain
{
    public class Brand:_EntityBase
    {
        public string? Name { get; set; }
        public byte[]? Logo { get; set; }


        public ICollection<Product> Products { get; set; }=new List<Product>();


    }

    public class BrandConfiguration:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.Property(p=>p.Name).IsRequired();
            builder.HasMany(p=>p.Products)
                .WithOne(p=>p.Brand)
                .HasForeignKey(p=>p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
