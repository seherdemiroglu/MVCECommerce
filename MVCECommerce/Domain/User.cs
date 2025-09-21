using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Domain
{

    public enum Genders
    {
        Male, Female
    }
    public class User : IdentityUser<Guid>
    {
        public required string GivenName { get; set; }
        public required DateTime Date { get; set; }
        public required Genders Gender { get; set; }

        public bool IsEnabled { get; set; }=true;

        public ICollection<Product> CreatedProducts { get; set; } = new List<Product>();
        public ICollection<Brand> CreatedBrands { get; set; } = new List<Brand>();
        public ICollection<CarouselImage> CreatedCarouselImages { get; set; } = new List<CarouselImage>();
        public ICollection<Catalog> CreatedCatalogs { get; set; } = new List<Catalog>();
        public ICollection<Category> CreatedCategories { get; set; } = new List<Category>();
        public ICollection<ProductImage> CreatedProductImages { get; set; } = new List<ProductImage>();
        public ICollection<Specification> CreatedSpecifications { get; set; } = new List<Specification>();

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<ShoppingCartItem> ShoppingCart { get; set; } = new List<ShoppingCartItem>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder
                .HasMany(p => p.Addresses).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(p => p.Comments).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(p => p.Orders).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder
                .HasMany(p => p.ShoppingCart).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .HasMany(p => p.CreatedProducts).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasMany(p => p.CreatedBrands).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasMany(p => p.CreatedCarouselImages).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasMany(p => p.CreatedCatalogs).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasMany(p => p.CreatedCategories).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasMany(p => p.CreatedProductImages).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            //builder
            //    .HasMany(p => p.CreatedSpecifications).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
