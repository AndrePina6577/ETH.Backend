using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The course category configuration.
/// </summary>
public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<CourseCategory> courseCategory)
    {
        Guard.Against.Null(courseCategory, nameof(courseCategory));

        courseCategory
            .HasKey(ct => ct.Id);

        courseCategory
            .Property(ct => ct.Name)
            .HasMaxLength(100)
            .IsRequired();

        courseCategory
            .Property(ca => ca.CreatedAt);

        courseCategory
            .Property(ca => ca.UpdatedAt);

        courseCategory
            .Property(ca => ca.Active);
    }
}
