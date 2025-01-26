using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PersonalFinanceApp.Application.Abstractions;
using PersonalFinanceApp.Application.Exceptions;
using PersonalFinanceApp.Application.Models.Authentication;

namespace PersonalFinanceApp.Identity.Services;

public sealed class AuthenticationService : IAuthenticationService
{
    private const string DefaultImage =
        "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";

    private readonly ILogger<AuthenticationService> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokensGenerator _tokensGenerator;

    public AuthenticationService(
        ILogger<AuthenticationService> logger,
        UserManager<ApplicationUser> userManager,
        ITokensGenerator tokensGenerator)
    {
        _logger = logger;
        _userManager = userManager;
        _tokensGenerator = tokensGenerator;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var (email, password) = request;
        _logger.LogInformation("User with email '{Email}' attempting to login", email);

        var applicationUser = await _userManager.FindByEmailAsync(email);
        if (applicationUser is not null)
        {
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(applicationUser, password);
            if (isPasswordCorrect)
            {
                var (accessToken, refreshToken) = _tokensGenerator.GenerateTokens(applicationUser);

                applicationUser.UpdateRefreshToken(refreshToken);
                await _userManager.UpdateAsync(applicationUser);

                return new LoginResponse(accessToken, refreshToken);
            }

            _logger.LogWarning("User with email '{Email}' attempted to login with wrong credentials", email);
        }

        _logger.LogInformation("Login failed for user with email '{Email}'", email);

        throw new UnauthorizedException();
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        var (firstName, lastName, email, password) = request;

        _logger.LogInformation("Registering new user with email '{Email}'", email);

        var applicationUser = new ApplicationUser(firstName, lastName, Convert.FromBase64String(DefaultImage))
        {
            Email = email,
            UserName = email
        };

        var identityResult = await _userManager.CreateAsync(applicationUser, password);
        if (!identityResult.Succeeded)
        {
            throw new ValidationException(
                identityResult.Errors.Select(e => new ValidationFailure(e.Code, e.Description)));
        }

        _logger.LogInformation("User registration for user with email '{Email}' was successful", email);
    }
}
