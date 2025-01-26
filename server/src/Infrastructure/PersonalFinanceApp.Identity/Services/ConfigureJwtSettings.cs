using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalFinanceApp.Identity.Models;

namespace PersonalFinanceApp.Identity.Services;

public sealed class ConfigureJwtSettings : IConfigureOptions<JwtSettings>, IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly RSA _rsa;

    public ConfigureJwtSettings(IConfiguration configuration)
    {
        _configuration = configuration;
        _rsa = RSA.Create();
    }

    public void Configure(JwtSettings options)
    {
        var authenticationSection = _configuration.GetSection("Authentication");
        var signingKey = authenticationSection["SigningKey"] ?? throw new InvalidOperationException("Signing key is not specified");

        _rsa.FromXmlString(signingKey);
        options.SigningCredentials = new SigningCredentials(new RsaSecurityKey(_rsa), SecurityAlgorithms.RsaSha256);
    }

    public void Dispose()
    {
        _rsa.Dispose();
    }
}
