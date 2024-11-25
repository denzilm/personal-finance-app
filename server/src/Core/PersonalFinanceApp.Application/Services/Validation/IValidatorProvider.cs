using FluentValidation.Results;

namespace PersonalFinanceApp.Application.Services.Validation;

public interface IValidatorProvider
{
    IAsyncEnumerable<ValidationResult> ValidateAsync<T>(T validatable, CancellationToken cancellationToken = default);
}
