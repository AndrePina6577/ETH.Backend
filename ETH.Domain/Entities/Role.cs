using System.ComponentModel.DataAnnotations;
using ETH.Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ETH.Domain.Entities;

public sealed class Role<TKey> : IdentityRole, IBaseEntity<string>
    where TKey : IEquatable<TKey>
{
    private Role()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Role{TKey}"/>.
    /// </summary>
    /// <param name="roleName">The role name.</param>
    public Role(string roleName) : this()
    {
        Name = roleName;
        CreatedAt = DateTimeOffset.Now;
    }
    /// <summary>
    /// Gets or sets the user type.
    /// </summary>
    [Required]
    public int UserType { get; set; }

    /// <inheritdoc />
    public bool? Active { get; set; }

    /// <inheritdoc />
    public DateTimeOffset CreatedAt { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <inheritdoc />
    public DateTimeOffset? DeletedAt { get; set; }

    /// <summary>
    /// Gets or sets the asp net user roles for this entity.
    /// </summary>
    public ICollection<UserRole<string>> AspNetUserRoles { get; set; }

    /// <inheritdoc />
    public bool ToPersist()
    {
        return false;
    }
}
