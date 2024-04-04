using System;
using Microsoft.AspNetCore.Identity;

namespace ETH.Api.TokenProviders.ChangeEmailConfirmation;

/// <summary>
/// The change email confirmation token provider options.
/// </summary>
public class ChangeEmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChangeEmailConfirmationTokenProviderOptions"/> class.
    /// </summary>
    public ChangeEmailConfirmationTokenProviderOptions()
    {
        Name = "EmailDataProtectorTokenProvider";
        TokenLifespan = TimeSpan.FromHours(24);
    }
}
