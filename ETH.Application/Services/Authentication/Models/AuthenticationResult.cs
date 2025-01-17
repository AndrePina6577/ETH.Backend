namespace ETH.Application.Services.Authentication.Models;

/// <summary>
/// The authentication result.
/// </summary>
public class AuthenticationResult
{
    /// <summary>
    /// The access token.
    /// </summary>
    public string AccessToken { get; init; }

    /// <summary>
    /// The refresh token.
    /// May be a new one or an existing one depending on expire date.
    /// </summary>
    public string RefreshToken { get; init; }

    /// <summary>
    /// The first name of the authenticated client.
    /// </summary>
    public string FirstName { get; init; }

    /// <summary>
    /// The last name of the authenticated client.
    /// </summary>
    public string LastName { get; init; }
}
