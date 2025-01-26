namespace PersonalFinanceApp.Identity.Services;

public interface ITokensGenerator
{
    (string AccessToken, string RefreshToken) GenerateTokens(ApplicationUser applicationUser);
}
