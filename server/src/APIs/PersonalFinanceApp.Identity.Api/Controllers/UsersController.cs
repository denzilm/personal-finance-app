using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Application.Features.Users.Commands.RegisterUser;
using PersonalFinanceApp.Shared.Hosting.Mvc;

using static PersonalFinanceApp.Application.Utility.Constants;

namespace PersonalFinanceApp.Identity.Api.Controllers;

[ApiVersion("1")]
[Route("api/v{api-version:apiVersion}/users")]
public sealed class UsersController : BaseController
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/v{api-version}/users
    ///     {
    ///         "firstName": "John",
    ///         "lastName": "Doe",
    ///         "email": "john.doe@example.com",
    ///         "password": "P@ssw0rd"
    ///         "confirmPassword": "P@ssw0rd"
    ///     }
    /// </remarks>
    /// <param name="request">User to register</param>
    [HttpPost("register", Name = RouteNames.RegisterUser)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [AllowAnonymous]
    public async Task<ActionResult> RegisterUser(RegisterUserCommand request)
    {
        await _sender.Send(request);
        return NoContent();
    }
}
