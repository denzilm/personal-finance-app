using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PersonalFinanceApp.Identity.Api.DesignTime;

public sealed class IdentityDbContextFactory : IDesignTimeDbContextFactory<PersonalFinanceAppIdentityContext>
{
    private const string IdentityDbMigrationsConnectionString =
        "PERSONAL_FINANCE_APP_IDENTITY_MIGRATIONS_CONNECTION_STRING";
    public PersonalFinanceAppIdentityContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable(IdentityDbMigrationsConnectionString);
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception($"Please set the environment variable {IdentityDbMigrationsConnectionString}");
        }

        var options = new DbContextOptionsBuilder<PersonalFinanceAppIdentityContext>()
            .UseSqlServer(connectionString, sqlServerOptions =>
            {
                sqlServerOptions
                    .EnableRetryOnFailure(
                        maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                sqlServerOptions.MigrationsAssembly(typeof(PersonalFinanceAppIdentityContext).Assembly.FullName);
            }).Options;

        return new PersonalFinanceAppIdentityContext(options);
    }
}
