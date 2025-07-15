using Microsoft.AspNetCore.Identity;

namespace MVCECommerce.Domain
{
    public class Role:IdentityRole<Guid>
    {
        public required string DisplayName { get; set; }
    }
}
