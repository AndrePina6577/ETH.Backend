using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The course session configuration.
/// </summary>
public class CourseSessionConfiguration : IEntityTypeConfiguration<CourseSession>
{
    public void Configure(EntityTypeBuilder<CourseSession> courseSession)
    {
        Guard.Against.Null(courseSession, nameof(courseSession));

        courseSession
            .HasKey(ct => ct.Id);

        courseSession
            .Property(cs => cs.Start)
            .IsRequired();

        courseSession
            .Property(cs => cs.End)
            .IsRequired();

        courseSession
            .Property(cs => cs.Status)
            .IsRequired();

        courseSession
            .HasOne(cs => cs.Location)
            .WithMany(c => c.CourseSessions)
            .HasForeignKey(cs => cs.LocationId);

        courseSession
            .HasOne(cs => cs.Course)
            .WithMany(c => c.CourseSessions)
            .HasForeignKey(cs => cs.CourseId);

        courseSession
            .Property(cs => cs.CreatedAt);

        courseSession
            .Property(cs => cs.UpdatedAt);

        courseSession
            .Property(cs => cs.Active);
    }
}
