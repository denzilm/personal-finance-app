using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using static PersonalFinanceApp.BFF.Utility.Constants;

namespace PersonalFinanceApp.BFF.Services;

public sealed class SignInManager : ISignInManager
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SignInManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task SignInAsync(string accessToken, string refreshToken)
    {
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        var properties = new AuthenticationProperties();
        properties.StoreTokens([
            new AuthenticationToken { Name = Authentication.AccessToken, Value = accessToken },
            new AuthenticationToken { Name = Authentication.RefreshToken, Value = refreshToken }
        ]);

        await _httpContextAccessor.HttpContext!.SignInAsync(new ClaimsPrincipal(identity));
    }

    public async Task SignOutAsync(string scheme)
    {
        await _httpContextAccessor.HttpContext!.SignOutAsync(scheme);
    }
}
