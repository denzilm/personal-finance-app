using FluentValidation.Results;

namespace PersonalFinanceApp.Application.Exceptions;

public sealed class ValidationException : Exception
{
    public IReadOnlyList<ValidationFailure> ValidationFailures { get; }

    public ValidationException(IEnumerable<ValidationFailure> errors)
    {
        ValidationFailures = [..errors];
    }
}
