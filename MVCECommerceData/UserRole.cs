using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCECommerceData;

public class UserRole : IdentityUserRole<Guid>
{
    public User? User { get; set; }
    public Role? Role { get; set; }
}

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        // Composite primary key (UserId + RoleId)
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        // Relationship: UserRole -> User
        builder
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        // Relationship: UserRole -> Role
        builder
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
}
