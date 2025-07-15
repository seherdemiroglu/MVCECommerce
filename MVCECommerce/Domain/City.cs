using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerce.Domain
{
    public class City
    {
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string? Name { get; set; }



        public ICollection<Address> Addresses { get; set; }=new List<Address>();
        public Province? Province { get; set;}
    }
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasIndex(p => new {p.Name,p.ProvinceId}).IsUnique();
            builder.Property(p=>p.Name).IsRequired();
            builder.HasMany(p => p.Addresses)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
