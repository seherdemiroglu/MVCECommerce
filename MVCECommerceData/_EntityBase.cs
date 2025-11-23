using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCECommerceData;

public abstract class _EntityBase
{
    public Guid Id { get; set; }
    //public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    [Display(Name="Aktif")]
    public bool IsEnabled { get; set; }=true;

    public User? User { get; set; }
}

public class _EntityBaseConfiguration : IEntityTypeConfiguration<_EntityBase>
{
    public void Configure(EntityTypeBuilder<_EntityBase> builder)
    {
        //tph table per hirerkey
        //tpt table per type: her tip için  bir tablo
        //builder.ToTable("_EntityBase");

    }
}
