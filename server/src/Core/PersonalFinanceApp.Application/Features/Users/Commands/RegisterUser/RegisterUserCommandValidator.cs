using System.Text.RegularExpressions;
using FluentValidation;

namespace PersonalFinanceApp.Application.Features.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().Length(2, 100)
            .WithMessage("'{PropertyName}' must be between 2 and 100 characters");
        RuleFor(c => c.LastName).NotEmpty().Length(2, 100)
            .WithMessage("'{PropertyName}' must be between 2 and 100 characters");
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Password).MinimumLength(6)
            .Must(HasValidPassword)
            .WithMessage("'{PropertyName}' should be at least 6 characters long with uppercase, digits and special characters");
        RuleFor(c => c.ConfirmPassword)
            .Equal(c => c.Password)
            .WithMessage("Passwords do not match");
    }

    private static bool HasValidPassword(string password)
    {
        var lowerCase = new Regex("[a-z]+");
        var upperCase = new Regex("[A-Z]+");
        var digit = new Regex("(\\d)+");
        var symbol = new Regex("(\\W)+");

        return
            lowerCase.IsMatch(password) && upperCase.IsMatch(password) &&
            digit.IsMatch(password) && symbol.IsMatch(password);
    }
}
