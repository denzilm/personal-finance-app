using System.Text.Json;
using FluentValidation.Results;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceApp.Application.Exceptions;

namespace PersonalFinanceApp.Shared.Hosting.ExceptionHandlers;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException) return false;

        var problemDetails = new ValidationProblemDetails(CreateErrorDictionary(validationException.ValidationFailures))
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "One or more validation errors occurred",
            Status = StatusCodes.Status400BadRequest
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response
            .WriteAsJsonAsync(
                problemDetails,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }, cancellationToken);

        return true;
    }

    private static Dictionary<string, string[]> CreateErrorDictionary(IEnumerable<ValidationFailure> failures)
    {
        var errorDictionary = new Dictionary<string, string[]>(StringComparer.Ordinal);
        foreach (var error in failures.GroupBy(e => e.PropertyName))
        {
            var key = error.Key;
            var errors = error.ToList();
            if (errors.Count == 1)
            {
                errorDictionary.Add(key, [errors[0].ErrorMessage]);
            }
            else
            {
                var errorMessages = new string[errors.Count];
                for (var i = 0; i < errors.Count; i++)
                {
                    errorMessages[i] = errors[i].ErrorMessage;
                }

                errorDictionary.Add(key, errorMessages);
            }
        }

        return errorDictionary;
    }
}
