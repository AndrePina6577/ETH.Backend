using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The course audience configuration.
/// </summary>
public class CourseAudienceConfiguration  : IEntityTypeConfiguration<CourseAudience>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<CourseAudience> courseAudience)
    {
        Guard.Against.Null(courseAudience, nameof(courseAudience));

        courseAudience
            .HasKey(ct => ct.Id);

        courseAudience
            .Property(ct => ct.Name)
            .HasMaxLength(100)
            .IsRequired();

        courseAudience
            .Property(ct => ct.Description)
            .HasMaxLength(500)
            .IsRequired();

        courseAudience
            .Property(ca => ca.CreatedAt);

        courseAudience
            .Property(ca => ca.UpdatedAt);

        courseAudience
            .Property(ca => ca.Active);
    }
}
