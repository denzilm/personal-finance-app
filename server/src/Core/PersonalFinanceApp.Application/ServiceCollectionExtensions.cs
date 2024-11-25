using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceApp.Application.Services.Validation;

namespace PersonalFinanceApp.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IValidatorProvider, ValidatorProvider>();

        return services;
    }
}
