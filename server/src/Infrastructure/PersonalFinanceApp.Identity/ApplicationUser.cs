using Microsoft.AspNetCore.Identity;

namespace PersonalFinanceApp.Identity;

public sealed class ApplicationUser : IdentityUser
{
    private const int RefreshTokenExpiryLength = 7;

    public ApplicationUser(
        string firstName, string lastName, byte[] avatar, string? refreshToken = null,
        DateTimeOffset? refreshTokenExpiryDate = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Avatar = avatar;
        RefreshToken = refreshToken;
        RefreshTokenExpiryDate = refreshTokenExpiryDate;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public byte[] Avatar { get; private set; }
    public string? RefreshToken { get; private set; }
    public DateTimeOffset? RefreshTokenExpiryDate { get; private set; }

    public bool HasValidRefreshToken(string refreshToken) =>
        RefreshToken == refreshToken && RefreshTokenExpiryDate > DateTimeOffset.UtcNow;

    public void UpdateRefreshToken(string refreshToken) =>
        (RefreshToken, RefreshTokenExpiryDate) = (refreshToken, DateTimeOffset.UtcNow.AddDays(RefreshTokenExpiryLength));
}
