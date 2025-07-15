using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date {  get; set; }
        public Guid UserId { get; set; }
        public Guid ShippingAddressId { get; set; }

        public User? User { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();


    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasMany(p=>p.Items).WithOne(p=>p.Order)
                .HasForeignKey(p=>p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
