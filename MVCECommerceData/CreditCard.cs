using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MVCECommerceData;

public class CreditCard
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Installment> Installments { get; set; } = new List<Installment>();
}

public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder
            .ToTable("CreditCards");

        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .HasMany(p => p.Installments)
            .WithOne(p => p.CreditCard)
            .HasForeignKey(p => p.CreditCardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasData(
                new CreditCard { Id = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Name = "axess" },
                new CreditCard { Id = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF1}"), Name = "world" },
                new CreditCard { Id = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF2}"), Name = "bonus" },
                new CreditCard { Id = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF3}"), Name = "maximum" },
                new CreditCard { Id = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF4}"), Name = "advantage" },
                new CreditCard { Id = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF5}"), Name = "bankkart" }
            );

    }
}


public class Installment
{
    public Guid Id { get; set; }
    public Guid CreditCardId { get; set; }
    public int Count { get; set; }
    public decimal Rate { get; set; }

    public CreditCard? CreditCard { get; set; }
}

public class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
{
    public void Configure(EntityTypeBuilder<Installment> builder)
    {
        builder
            .ToTable("Installments");

        builder
            .HasData(
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC000}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Count = 2, Rate = 1 },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC001}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Count = 3, Rate = 1 },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC012}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Count = 4, Rate = 1 },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC002}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Count = 6, Rate = 1 },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC003}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Count = 8, Rate = 1.1m },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC004}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Count = 9, Rate = 1.20m },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC005}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF0}"), Count = 12, Rate = 1.30m },

            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC006}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF1}"), Count = 2, Rate = 1 },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC007}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF1}"), Count = 3, Rate = 1 },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC008}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF1}"), Count = 6, Rate = 1 },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC009}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF1}"), Count = 8, Rate = 1.15m },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC010}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF1}"), Count = 9, Rate = 1.25m },
            new Installment { Id = Guid.Parse("{7B059AE7-C6B2-4F5E-8316-204BB01FC011}"), CreditCardId = Guid.Parse("{022988E2-D3C2-4619-8B9D-57E0D1374FF1}"), Count = 12, Rate = 1.35m }

            );
    }
}


