using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerce.Domain
{
    public class Address
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public string? ZipCode { get; set; }
        public int CityId { get; set; }

        public City? City { get; set; }
        public User? User { get; set; }
    }

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p=>p.Text).IsRequired();

        }
    }
}
