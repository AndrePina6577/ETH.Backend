using ETH.Application.Services.Authentication.Models;

namespace ETH.Application.Services.Authentication;

/// <summary>
/// The authentication service.
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    /// <inheritdoc />
    public Task<AuthenticationResult> Login(LoginRequest model)
    {
        return Task.FromResult(new AuthenticationResult());
    }
}
