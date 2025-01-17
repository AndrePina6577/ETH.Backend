using System.Threading.Tasks;
using Ardalis.GuardClauses;
using ETH.Application.Services.Authentication;
using ETH.Application.Services.Authentication.Models;
using ETH.Contracts.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETH.Api.Controllers;

/// <summary>
/// The authentication controller.
/// </summary>
[ApiController]
[Tags("Authentication")]
[Route("api/auth")]
[Produces("application/json")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
    /// </summary>
    /// <param name="authenticationService">The authentication service.</param>
    public AuthenticationController(
        IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    /// <summary>
    /// Authenticates the user, returning an access token.
    /// </summary>
    /// <param name="request">The login request model.</param>
    /// <returns>An access token.</returns>
    /// <response code="200">Returns an access and refresh token.</response>
    /// <response code="500">Something happened, check kibana for more information.</response>
    [AllowAnonymous]
    [HttpPost("Login")]
    [ProducesResponseType(typeof(AuthenticationResponseModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(LoginRequestModel request)
    {
        Guard.Against.Null(request, nameof(LoginRequestModel));

        var result = await _authenticationService.Login(new LoginRequest
        {
            Email = request.Email,
            Password = request.Password,
        });

        return Ok(new AuthenticationResponseModel
        {
            AccessToken = result.AccessToken,
            FirstName = result.FirstName,
            LastName = result.LastName,
            RefreshToken = result.RefreshToken,
        });
    }
}
