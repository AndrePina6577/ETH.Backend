using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ETH.Api.TokenProviders.ChangeEmailConfirmation;

/// <summary>
/// The change email confirmation token provider.
/// </summary>
public class CustomChangeEmailConfirmationTokenProvider<TUser> : DataProtectorTokenProvider<TUser>
    where TUser : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomChangeEmailConfirmationTokenProvider{TUser}"/> class.
    /// </summary>
    /// <param name="dataProtectionProvider">The data protection provider.</param>
    /// <param name="options">The token provider options.</param>
    /// <param name="logger">The logger.</param>
    public CustomChangeEmailConfirmationTokenProvider(
        IDataProtectionProvider dataProtectionProvider,
        IOptions<ChangeEmailConfirmationTokenProviderOptions> options,
        ILogger<CustomChangeEmailConfirmationTokenProvider<TUser>> logger)
        : base(dataProtectionProvider, options, logger)
    {

    }
}
