namespace ETH.Application.Services.Authentication.Models;

/// <summary>
/// The login request model.
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Password { get; init; }
}
