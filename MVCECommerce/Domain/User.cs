using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Domain
{

    public enum Genders
    {
        Male, Female
    }
    public class User:IdentityUser<Guid>
    {
        public required string GivenName { get; set; }
        public required DateTime Date { get; set; }
        public required Genders Gender { get; set; }


        public ICollection<Address> Addresses { get; set; }=new List<Address>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Order> Orders { get; set; }= new List<Order>();
        public ICollection<ShoppingCartItem> ShoppingCart { get; set; } = new List<ShoppingCartItem>();

    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(p => p.Addresses).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(p => p.Comments).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(p => p.Orders).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(p => p.ShoppingCart).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
