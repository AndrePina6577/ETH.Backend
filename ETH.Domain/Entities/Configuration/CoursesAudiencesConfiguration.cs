using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The courses audiences configuration.
/// </summary>
public class CoursesAudiencesConfiguration : IEntityTypeConfiguration<CoursesAudiences>
{
    public void Configure(EntityTypeBuilder<CoursesAudiences> coursesAudiences)
    {
        Guard.Against.Null(coursesAudiences, nameof(coursesAudiences));

        coursesAudiences
            .HasKey(ct => new { ct.CourseId, ct.CourseAudienceId });

        coursesAudiences
            .HasOne(ct => ct.Course)
            .WithMany(c => c.CoursesAudiences)
            .HasForeignKey(ct => ct.CourseId)
            .IsRequired();

        coursesAudiences
            .HasOne(ct => ct.CourseAudience)
            .WithMany(c => c.CoursesAudiences)
            .HasForeignKey(ct => ct.CourseAudienceId)
            .IsRequired();

        coursesAudiences
            .Property(ca => ca.CreatedAt);

        coursesAudiences
            .Property(ca => ca.UpdatedAt);

        coursesAudiences
            .Property(ca => ca.Active);
    }
}
