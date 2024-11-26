using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using PersonalFinanceApp.Application.Services.Validation;

namespace PersonalFinanceApp.Application.Utility;

public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected readonly ILogger Logger;
    private readonly IValidatorProvider _validatorProvider;

    protected CommandHandler(ILogger logger, IValidatorProvider validatorProvider)
    {
        Logger = logger;
        _validatorProvider = validatorProvider;
    }

    protected abstract Task<TResponse> OnHandle(TRequest request, CancellationToken cancellationToken = default);

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default)
    {
        var errors = new List<ValidationFailure>();
        await foreach (var result in _validatorProvider.ValidateAsync(request, cancellationToken))
        {
            if (!result.IsValid) errors.AddRange(result.Errors);
        }

        if (errors.Count > 0) throw new Exceptions.ValidationException(errors);

        return await OnHandle(request, cancellationToken);
    }
}
