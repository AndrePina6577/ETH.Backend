namespace ETH.Contracts.Authentication;

/// <summary>
/// The login request model.
/// </summary>
public class LoginRequestModel
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
