using FluentValidation.Results;
using MediatR;
using PersonalFinanceApp.Application.Exceptions;
using PersonalFinanceApp.Application.Services.Validation;

namespace PersonalFinanceApp.Application.MediatRPipelineBehaviors.Validation;

public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IValidatorProvider _validatorProvider;

    public ValidationBehavior(IValidatorProvider validatorProvider)
    {
        _validatorProvider = validatorProvider;
    }

    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var errors = new List<ValidationFailure>();
        await foreach (var result in _validatorProvider.ValidateAsync(request, cancellationToken))
        {
            if (!result.IsValid) errors.AddRange(result.Errors);
        }

        if (errors.Count != 0) throw new ValidationException(errors);

        return await next();
    }
}
