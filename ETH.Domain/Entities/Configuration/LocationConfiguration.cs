using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The location configuration.
/// </summary>
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Location> location)
    {
        Guard.Against.Null(location, nameof(location));

        location
            .HasKey(l => l.Id);

        location
            .Property(l => l.Name)
            .HasMaxLength(100)
            .IsRequired();

        location
            .Property(ca => ca.CreatedAt);

        location
            .Property(ca => ca.UpdatedAt);

        location
            .Property(ca => ca.Active);
    }
}
