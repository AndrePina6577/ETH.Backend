using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ETH.Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ETH.Domain.Entities;

/// <summary>
/// The application user.
/// </summary>
public class User : IdentityUser, IBaseEntity<string>
{
    /// <summary>
    /// Gets or sets the user type.
    /// </summary>
    [Required]
    public int UserType { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether user has changed password.
    /// </summary>
    [Required]
    [DefaultValue(false)]
    public bool HasChangedPassword { get; set; }

    /// <summary>
    /// Gets or sets the unconfirmed email expiration date.
    /// </summary>
    public DateTimeOffset? UnconfirmedEmailExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets the unconfirmed email.
    /// </summary>
    [MaxLength(256)]
    public string UnconfirmedEmail { get; set; }

    /// <summary>
    /// Gets or sets the email confirmed previous value.
    /// </summary>
    public bool? EmailConfirmedPreviousValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether user has a confirmed facebook account.
    /// </summary>
    [Required]
    public bool IsFacebookConfirmed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether user has a confirmed google plus account.
    /// </summary>
    [Required]
    public bool IsGooglePlusConfirmed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether user has a confirmed identity.
    /// </summary>
    [Required]
    public bool IsIdentityConfirmed { get; set; }

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
