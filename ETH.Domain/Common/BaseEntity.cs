using ETH.Domain.Common.Interfaces;

namespace ETH.Domain.Common;

/// <summary>
/// The base entity.
/// </summary>
public class BaseEntity<TKey> : IBaseEntity<TKey>
{
    /// <inheritdoc cref="IBaseEntity.Id"/>
    public virtual TKey Id { get; set; }

    /// <inheritdoc cref="IBaseEntity.Active"/>
    public bool? Active { get; set; }

    /// <inheritdoc cref="IBaseEntity.CreatedAt"/>
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc cref="IBaseEntity.UpdatedAt"/>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <inheritdoc cref="IBaseEntity.DeletedAt"/>
    public DateTimeOffset? DeletedAt { get; set; }

    /// <inheritdoc cref="IBaseEntity.ToPersist"/>
    public virtual bool ToPersist()
    {
        return false;
    }
}
