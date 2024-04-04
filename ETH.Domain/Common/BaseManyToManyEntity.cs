using ETH.Domain.Common.Interfaces;

namespace ETH.Domain.Common;

/// <summary>
/// The base many to many entity.
/// </summary>
public class BaseManyToManyEntity : IBaseManyToManyEntity
{
    /// <inheritdoc cref="IBaseManyToManyEntity.Active"/>
    public bool? Active { get; set; }

    /// <inheritdoc cref="IBaseManyToManyEntity.CreatedAt"/>
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc cref="IBaseManyToManyEntity.UpdatedAt"/>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <inheritdoc cref="IBaseManyToManyEntity.DeletedAt"/>
    public DateTimeOffset? DeletedAt { get; set; }

    /// <inheritdoc cref="IBaseManyToManyEntity.ToPersist"/>
    public virtual bool ToPersist()
    {
        return false;
    }
}
