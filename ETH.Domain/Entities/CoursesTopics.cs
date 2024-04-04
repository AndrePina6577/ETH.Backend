using ETH.Domain.Common.Interfaces;

namespace ETH.Domain.Entities;

/// <summary>
/// The courses topics.
/// </summary>
public class CoursesTopics : IBaseManyToManyEntity
{
    public int CourseId { get; set; }

    public Course Course { get; set; }

    public int CourseTopicId { get; set; }

    public CourseTopic CourseTopic { get; set; }

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
