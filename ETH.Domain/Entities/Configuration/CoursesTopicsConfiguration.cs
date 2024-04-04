using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The courses topics configuration.
/// </summary>
public class CoursesTopicsConfiguration : IEntityTypeConfiguration<CoursesTopics>
{
    public void Configure(EntityTypeBuilder<CoursesTopics> coursesTopics)
    {
        Guard.Against.Null(coursesTopics, nameof(coursesTopics));

        coursesTopics
            .HasKey(ct => new { ct.CourseId, ct.CourseTopicId });

        coursesTopics
            .HasOne(ct => ct.Course)
            .WithMany(c => c.CoursesTopics)
            .HasForeignKey(ct => ct.CourseId)
            .IsRequired();

        coursesTopics
            .HasOne(ct => ct.CourseTopic)
            .WithMany(c => c.CoursesTopics)
            .HasForeignKey(ct => ct.CourseTopicId)
            .IsRequired();

        coursesTopics
            .Property(ca => ca.CreatedAt);

        coursesTopics
            .Property(ca => ca.UpdatedAt);

        coursesTopics
            .Property(ca => ca.Active);
    }
}
