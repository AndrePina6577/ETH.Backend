using ETH.Domain.Common.Interfaces;

namespace ETH.Domain.Entities;

/// <summary>
/// The courses audiences.
/// </summary>
public class CoursesAudiences : IBaseManyToManyEntity
{
    public int CourseId { get; set; }

    public Course Course { get; set; }

    public int CourseAudienceId { get; set; }

    public CourseAudience CourseAudience { get; set; }

    /// <inheritdoc />
    public bool? Active { get; set; }

    /// <inheritdoc />
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? DeletedAt { get; set; }

    /// <inheritdoc />
    public bool ToPersist()
    {
        return false;
    }
}
