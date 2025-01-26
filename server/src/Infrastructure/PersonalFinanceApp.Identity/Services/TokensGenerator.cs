using System.Buffers.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using PersonalFinanceApp.Identity.Models;

namespace PersonalFinanceApp.Identity.Services;

public sealed class TokensGenerator : ITokensGenerator
{
    private readonly JwtSettings _jwtSettings;

    public TokensGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public (string AccessToken, string RefreshToken) GenerateTokens(ApplicationUser applicationUser)
    {
        var refreshToken = GenerateRefreshToken();

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, applicationUser.Id),
            new(JwtRegisteredClaimNames.Jti, _jwtSettings.JtiGenerator()),
            new(JwtRegisteredClaimNames.Iat, _jwtSettings.IssuedAt.ToUnixTimeSeconds().ToString()),
            new(JwtRegisteredClaimNames.GivenName, applicationUser.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, applicationUser.LastName),
            new(JwtRegisteredClaimNames.Email, applicationUser.Email!)
        ];

        claims.AddRange(_jwtSettings.Audiences
            .Select(audience => new Claim(JwtRegisteredClaimNames.Aud, audience)));

        var jwt = new JwtSecurityToken(
            _jwtSettings.Issuer, null, claims, _jwtSettings.NotBefore.UtcDateTime,
            _jwtSettings.Expiration(TimeSpan.FromMinutes(5)).UtcDateTime, _jwtSettings.SigningCredentials);

        return (new JwtSecurityTokenHandler().WriteToken(jwt), refreshToken);

        static string GenerateRefreshToken()
        {
            using var rng = RandomNumberGenerator.Create();

            var bytes = new byte[32];
            rng.GetBytes(bytes);

            return Base64Url.EncodeToString(bytes);
        }
    }
}
