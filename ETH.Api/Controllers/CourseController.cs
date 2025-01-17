using System.Threading.Tasks;
using Ardalis.GuardClauses;
using ETH.Api.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETH.Api.Controllers;

[ApiController]
[Tags("Course")]
[Produces("application/json")]
[Route("api/[controller]/[action]")]
public class CourseController : ControllerBase
{
    /// <summary>
    /// Gets courses according to filters.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>A list of filtered courses.</returns>
    [HttpPost]
    public async Task<IActionResult> GetAll(GetCoursesRequestModel request)
    {
        Guard.Against.Null(request, nameof(GetCoursesRequestModel));

        return null;
    }
}
