using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.Property(p => p.Price).HasPrecision(18, 4);

        }
    }
}
