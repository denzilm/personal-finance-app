using FluentValidation.TestHelper;
using PersonalFinanceApp.Application.Features.Users.Commands.RegisterUser;

namespace PersonalFinanceApp.Application.Tests.Features.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandValidatorTests
{
    private readonly RegisterUserCommandValidator _validator = new();

    private readonly RegisterUserCommand _command = new RegisterUserCommand
    {
        FirstName = "John",
        LastName = "Doe",
        Email = "jack@example.com",
        Password = "P@ssw0rd",
        ConfirmPassword = "P@ssw0rd"
    };

    [Fact]
    public void ShouldHaveValidationError_When_FirstName_Empty()
    {
        var command = _command with { FirstName = "" };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void ShouldHaveValidationError_When_FirstName_LongerThan100()
    {
        var command = _command with { FirstName = new string('a', 101)};

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void ShouldHaveValidationError_When_LastName_Empty()
    {
        var command = _command with { LastName = "" };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Fact]
    public void ShouldHaveValidationError_When_LastName_LongerThan100()
    {
        var command = _command with { LastName = new string('a', 101)};

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.LastName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("plainaddress")]
    [InlineData("@missingusername.com")]
    [InlineData("username@domain@domain.com")]
    [InlineData("username@domain@domain.c")]
    public void ShouldHaveValidationError_When_Email_IsNotValid(string email)
    {
        var command = _command with { Email = email };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Theory]
    [InlineData("")]
    [InlineData("onlylowercase")]
    [InlineData("Sh0r#")]
    [InlineData("NoSymb0l")]
    [InlineData("N#Number")]
    public void ShouldHaveValidationError_When_Password_NotAdheringToCriteria(string password)
    {
        var command = _command with { Password = password };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Fact]
    public void ShouldHaveValidationError_When_ConfirmationPasswordDoesNotMatch()
    {
        var command = _command with { Password = "Passw0rd", ConfirmPassword = "PassW0rd" };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.ConfirmPassword);
    }

    [Fact]
    public void ShouldNotHaveValidationError_When_AdheringToCriteria()
    {
        var result = _validator.TestValidate(_command);

        result.ShouldNotHaveAnyValidationErrors();
    }
}
