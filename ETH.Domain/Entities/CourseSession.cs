using ETH.Domain.Common.Interfaces;

namespace ETH.Domain.Entities;

/// <summary>
/// The course session.
/// Represents when and where a course can take place.
/// </summary>
public class CourseSession : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the start.
    /// </summary>
    public DateTimeOffset Start { get; set; }

    /// <summary>
    /// Gets or sets the end.
    /// </summary>
    public DateTimeOffset End { get; set; }

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Gets or sets the location identifier.
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// The location's navigation property.
    /// </summary>
    public Location Location { get; set; }

    /// <summary>
    /// Gets or sets the course identifier.
    /// </summary>
    public int CourseId { get; set; }

    /// <summary>
    /// The course's navigation property.
    /// </summary>
    public Course Course { get; set; }

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
