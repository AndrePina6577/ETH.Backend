using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The course configuration.
/// </summary>
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Course> course)
    {
        Guard.Against.Null(course, nameof(course));

        course
            .HasKey(c => c.Id);

        course
            .Property(c => c.CustomId)
            .HasMaxLength(50)
            .IsRequired();

        course
            .HasIndex(c => c.CustomId)
            .IsUnique();

        course
            .Property(c => c.Name)
            .HasMaxLength(300)
            .IsRequired();

        course
            .Property(ca => ca.CreatedAt);

        course
            .Property(ca => ca.UpdatedAt);

        course
            .Property(ca => ca.Active);
    }
}
