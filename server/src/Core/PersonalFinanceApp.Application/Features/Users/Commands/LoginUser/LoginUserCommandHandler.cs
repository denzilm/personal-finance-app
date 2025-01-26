using MediatR;
using PersonalFinanceApp.Application.Abstractions;
using PersonalFinanceApp.Application.Models.Authentication;

namespace PersonalFinanceApp.Application.Features.Users.Commands.LoginUser;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var (email, password) = request;

        return await _authenticationService.LoginAsync(new LoginRequest(email, password));
    }
}
