using MediatR;
using Microsoft.Extensions.Logging;
using PersonalFinanceApp.Application.Abstractions;
using PersonalFinanceApp.Application.Models.Authentication;
using PersonalFinanceApp.Application.Services.Validation;
using PersonalFinanceApp.Application.Utility;

namespace PersonalFinanceApp.Application.Features.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand, Unit>
{
    private readonly IAuthenticationService _authenticationService;

    public RegisterUserCommandHandler(
        ILogger<RegisterUserCommandHandler> logger,
        IValidatorProvider validatorProvider,
        IAuthenticationService authenticationService) : base(logger, validatorProvider)
    {
        _authenticationService = authenticationService;
    }

    protected override async Task<Unit> OnHandle(RegisterUserCommand request, CancellationToken cancellationToken = default)
    {
        var (firstName, lastName, email, password) = request;
        await _authenticationService.RegisterAsync(new RegisterRequest(firstName, lastName, email, password));

        Logger.LogInformation("User with email '{Email}' registered successfully", email);

        return Unit.Value;
    }
}
