using ETH.Application.Services.Authentication.Models;

namespace ETH.Application.Services.Authentication;

/// <summary>
/// The interface for the authentication service.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Authenticates the user, generating an access token.
    /// </summary>
    /// <param name="model">The login request.</param>
    /// <returns>The login result.</returns>
    Task<AuthenticationResult> Login(LoginRequest model);
}
