using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Domain
{
    public class CarouselImage : _EntityBase
    {
        public byte[] Image { get; set; }
        public string? Url { get; set; }
        public Guid? CategoryId { get; set; } //zero or one to many bağlantı, katalogu olmayabilir yada bir kataloğa bağlı olabilir

    }

    public class CarouselImageConfiguration : IEntityTypeConfiguration<CarouselImage>
    {
        public void Configure(EntityTypeBuilder<CarouselImage> builder)
        {
            builder.ToTable("CarouselImages");
            builder.Property(p => p.Image).IsRequired();


        }
    }
}
