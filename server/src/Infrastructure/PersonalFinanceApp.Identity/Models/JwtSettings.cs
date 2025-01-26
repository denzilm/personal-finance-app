using Microsoft.IdentityModel.Tokens;

namespace PersonalFinanceApp.Identity.Models;

public sealed record JwtSettings
{
    public DateTimeOffset IssuedAt => DateTimeOffset.UtcNow;
    public DateTimeOffset Expiration(TimeSpan validFor) => IssuedAt.Add(validFor);
    public DateTimeOffset NotBefore => DateTimeOffset.UtcNow;
    public string JtiGenerator() => Guid.NewGuid().ToString();

    public required string Issuer { get; init; }
    public required SigningCredentials SigningCredentials { get; set; }
    public required IReadOnlyList<string> Audiences { get; init; }
}
