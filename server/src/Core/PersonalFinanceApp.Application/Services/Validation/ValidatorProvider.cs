using System.Runtime.CompilerServices;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalFinanceApp.Application.Services.Validation;

public sealed class ValidatorProvider : IValidatorProvider
{
    private readonly IServiceProvider _serviceProvider;

    public ValidatorProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async IAsyncEnumerable<ValidationResult> ValidateAsync<T>(
        T validatable, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (var result in _serviceProvider.GetServices<IValidator<T>>()
                           .ValidateAsync(new ValidationContext<T>(validatable), cancellationToken))
        {
            yield return result;
        }
    }
}
