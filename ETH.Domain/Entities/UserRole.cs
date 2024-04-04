using System.ComponentModel.DataAnnotations.Schema;
using ETH.Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ETH.Domain.Entities;

/// <summary>
/// The application user role.
/// </summary>
public class UserRole<TKey> : IdentityUserRole<TKey>, IBaseManyToManyEntity
    where TKey : IEquatable<TKey>
{
    [ForeignKey(nameof(RoleId))]
    public Role<TKey> Role { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public bool? Active { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }

    public bool ToPersist()
    {
        return true;
    }
}
