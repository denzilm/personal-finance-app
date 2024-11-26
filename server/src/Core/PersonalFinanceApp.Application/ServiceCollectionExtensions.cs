using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceApp.Application.Services.Validation;

namespace PersonalFinanceApp.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IValidatorProvider, ValidatorProvider>();

        return services;
    }
}
