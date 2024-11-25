using System.Runtime.CompilerServices;
using FluentValidation;
using FluentValidation.Results;

namespace PersonalFinanceApp.Application.Services.Validation;

public static class ValidationExtensions
{
    public static async IAsyncEnumerable<ValidationResult> ValidateAsync(
        this IEnumerable<IValidator> validators, IValidationContext validationContext,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var validator in validators)
        {
            yield return await validator.ValidateAsync(validationContext, cancellationToken);
        }
    }
}
