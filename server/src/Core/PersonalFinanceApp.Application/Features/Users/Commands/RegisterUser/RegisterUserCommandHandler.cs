using MediatR;
using Microsoft.Extensions.Logging;
using PersonalFinanceApp.Application.Abstractions;
using PersonalFinanceApp.Application.Models.Authentication;

namespace PersonalFinanceApp.Application.Features.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    private readonly ILogger<RegisterUserCommandHandler> _logger;
    private readonly IAuthenticationService _authenticationService;

    public RegisterUserCommandHandler(
        ILogger<RegisterUserCommandHandler> logger, IAuthenticationService authenticationService)
    {
        _logger = logger;
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken = default)
    {
        var (firstName, lastName, email, password) = request;
        await _authenticationService.RegisterAsync(new RegisterRequest(firstName, lastName, email, password));

        _logger.LogInformation("User with email '{Email}' registered successfully", email);

        return Unit.Value;
    }
}
