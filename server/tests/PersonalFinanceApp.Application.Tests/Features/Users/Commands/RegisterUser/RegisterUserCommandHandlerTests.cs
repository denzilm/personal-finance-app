using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using PersonalFinanceApp.Application.Abstractions;
using PersonalFinanceApp.Application.Features.Users.Commands.RegisterUser;
using PersonalFinanceApp.Application.Models.Authentication;
using PersonalFinanceApp.Application.Services.Validation;

namespace PersonalFinanceApp.Application.Tests.Features.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandHandlerTests
{
    private readonly Mock<ILogger<RegisterUserCommandHandler>> _logger = new();
    private readonly Mock<IValidatorProvider> _validatorProvider = new();
    private readonly Mock<IAuthenticationService> _authenticationService = new();

    [Fact]
    public async Task RegisterUserCommandHandler_ShouldRegisterUser()
    {
        var sut = new RegisterUserCommandHandler(
            _logger.Object, _validatorProvider.Object, _authenticationService.Object);

        _validatorProvider.Setup(x => x.ValidateAsync(It.IsAny<RegisterUserCommand>(), CancellationToken.None))
            .Returns(new List<ValidationResult> { new() { Errors = [] } }.ToAsyncEnumerable());

        await sut.Handle(
            new RegisterUserCommand
            {
                FirstName = It.IsAny<string>(),
                LastName = It.IsAny<string>(),
                Email = It.IsAny<string>(),
                Password = It.IsAny<string>(),
                ConfirmPassword = It.IsAny<string>()
            });

        _authenticationService
            .Verify(
                x => x.RegisterAsync(
                    new RegisterRequest(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())), Times.Once);
    }
}
