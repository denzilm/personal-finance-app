using MediatR;

namespace PersonalFinanceApp.Application.Features.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand : IRequest<Unit>
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string ConfirmPassword { get; init; }

    public void Deconstruct(out string firstName, out string lastName, out string email, out string password)
    {
        firstName = FirstName;
        lastName = LastName;
        email = Email;
        password = Password;
    }
}
