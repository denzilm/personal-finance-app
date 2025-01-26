namespace PersonalFinanceApp.BFF.Services;

public interface ISignInManager
{
    Task SignInAsync(string accessToken, string refreshToken);
    Task SignOutAsync(string scheme);
}
