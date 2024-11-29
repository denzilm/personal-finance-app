using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceApp.Identity;

public sealed class PersonalFinanceAppIdentityContext : IdentityDbContext<ApplicationUser>
{
    public PersonalFinanceAppIdentityContext(DbContextOptions<PersonalFinanceAppIdentityContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
