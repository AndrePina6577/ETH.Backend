namespace ETH.Domain.Common.Interfaces;

/// <summary>
/// The interface for the base many to many entity.
/// </summary>
public interface IBaseManyToManyEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether is active.
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Gets or sets the created at.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the updated at.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the deleted at.
    /// </summary>
    public DateTimeOffset? DeletedAt { get; set; }

    /// <summary>
    /// Gets a value indicating whether action should be persisted.
    /// </summary>
    /// <returns>A value indicating whether action should be persisted.</returns>
    bool ToPersist();
}
