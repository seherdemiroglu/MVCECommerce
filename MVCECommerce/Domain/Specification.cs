using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerce.Domain
{
    public class Specification : _EntityBase
    {
        #region Scalar
        public string? NameTr { get; set; }
        public string? NameEn { get; set; }
        public Guid CategoryId { get; set; }
        #endregion

        #region Navigation
        public Category? Category { get; set; }

        #endregion
    }

    public class SpecificationConfiguration : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder
                .ToTable("Specifications");

            builder
                .HasIndex(p => new { p.NameTr });

            builder
                .HasIndex(p => new { p.NameEn });

            builder
                .Property(p => p.NameTr)
                .IsRequired();

            builder
                .Property(p => p.NameEn)
                .IsRequired();

        }
    }

}
