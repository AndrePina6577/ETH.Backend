using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ETH.Domain.Common.Interfaces;
using ETH.Domain.Entities.Configuration;

namespace ETH.Domain.Entities;

/// <summary>
/// The course.
/// </summary>
public class Course : IBaseEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the custom identifier.
    /// </summary>
    public string CustomId { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the course sessions.
    /// </summary>
    public IEnumerable<CourseSession> CourseSessions { get; set; }

    /// <summary>
    /// The courses topics.
    /// </summary>
    public IEnumerable<CoursesTopics> CoursesTopics { get; set; }

    /// <summary>
    /// The courses categories.
    /// </summary>
    public IEnumerable<CoursesCategories> CoursesCategories { get; set; }

    /// <summary>
    /// The courses audiences.
    /// </summary>
    public IEnumerable<CoursesAudiences> CoursesAudiences { get; set; }

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
