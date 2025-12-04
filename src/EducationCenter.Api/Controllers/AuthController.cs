// CA1515: Controllers must be public for ASP.NET Core routing; suppress for this class.
#pragma warning disable CA1515
using EducationCenter.Service.Auth.Models;
using EducationCenter.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationCenter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async ValueTask<ActionResult<AuthResult>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.LoginAsync(request, cancellationToken).ConfigureAwait(false);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async ValueTask<ActionResult<AuthResult>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.RegisterAsync(request, cancellationToken).ConfigureAwait(false);
        return Ok(result);
    }
}
#pragma warning restore CA1515
