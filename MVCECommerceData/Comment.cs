using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerceData;

public class Comment
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public int Score { get; set; }
    public string? Text { get; set; }

    public User? User { get; set; }
    public Product? Product { get; set; }
}

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.HasIndex(p => p.Date).IsDescending();
        builder.Property(p => p.Text).IsRequired();

    }
}
