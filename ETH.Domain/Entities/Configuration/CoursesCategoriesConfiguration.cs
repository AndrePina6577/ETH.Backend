using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ETH.Domain.Entities.Configuration;

/// <summary>
/// The courses topics configuration.
/// </summary>
public class CoursesCategoriesConfiguration : IEntityTypeConfiguration<CoursesCategories>
{
    public void Configure(EntityTypeBuilder<CoursesCategories> coursesCategories)
    {
        Guard.Against.Null(coursesCategories, nameof(coursesCategories));

        coursesCategories
            .HasKey(ct => new { ct.CourseId, ct.CourseCategoryId });

        coursesCategories
            .HasOne(ct => ct.Course)
            .WithMany(c => c.CoursesCategories)
            .HasForeignKey(ct => ct.CourseId)
            .IsRequired();

        coursesCategories
            .HasOne(ct => ct.CourseCategory)
            .WithMany(c => c.CoursesCategories)
            .HasForeignKey(ct => ct.CourseCategoryId)
            .IsRequired();

        coursesCategories
            .Property(ca => ca.CreatedAt);

        coursesCategories
            .Property(ca => ca.UpdatedAt);

        coursesCategories
            .Property(ca => ca.Active);
    }
}
