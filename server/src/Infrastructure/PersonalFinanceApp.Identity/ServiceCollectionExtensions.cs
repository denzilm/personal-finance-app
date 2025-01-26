using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PersonalFinanceApp.Application.Abstractions;
using PersonalFinanceApp.Identity.Models;
using PersonalFinanceApp.Identity.Services;

namespace PersonalFinanceApp.Identity;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureIdentity(this IServiceCollection services, string connectionString, IConfiguration configuration)
    {
        services.AddDbContext<PersonalFinanceAppIdentityContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptions =>
            {
                sqlServerOptions
                    .EnableRetryOnFailure(maxRetryCount: 5, TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            });
        });

        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<PersonalFinanceAppIdentityContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtSettings>(configuration.GetSection("Authentication"));
        services.AddSingleton<IConfigureOptions<JwtSettings>, ConfigureJwtSettings>();
        services.AddScoped<ITokensGenerator, TokensGenerator>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
