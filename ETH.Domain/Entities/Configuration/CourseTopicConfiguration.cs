using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The course topic configuration.
/// </summary>
public class CourseTopicConfiguration  : IEntityTypeConfiguration<CourseTopic>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<CourseTopic> courseTopic)
    {
        Guard.Against.Null(courseTopic, nameof(courseTopic));

        courseTopic
            .HasKey(ct => ct.Id);

        courseTopic
            .Property(ct => ct.Name)
            .HasMaxLength(100)
            .IsRequired();

        courseTopic
            .Property(ca => ca.CreatedAt);

        courseTopic
            .Property(ca => ca.UpdatedAt);

        courseTopic
            .Property(ca => ca.Active);
    }
}
