using ETH.Domain.Common.Interfaces;
using ETH.Domain.Entities.Configuration;

namespace ETH.Domain.Entities;

/// <summary>
/// The course topic.
/// </summary>
public class CourseTopic : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The courses topics.
    /// </summary>
    public IEnumerable<CoursesTopics> CoursesTopics { get; set; }

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
