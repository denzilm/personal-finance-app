using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PersonalFinanceApp.Shared.Hosting.OperationFilters;

public sealed class ProblemDetailsOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        foreach (var operationResponse in operation.Responses
                                              .Where(operationResponse =>
                                                  operationResponse.Key.StartsWith('4') ||
                                                  operationResponse.Key.StartsWith('5')))
        {
            var description = operationResponse.Key switch
            {
                "400" => "There was a validation error",
                "401" => "Unable to authenticate",
                "403" => "Access to the resource is forbidden",
                "404" => "The resource does not exist",
                "406" => "Not acceptable media type",
                "409" => "The resource already exists",
                _ => "The server was unable to process your request"
            };

            operation.Responses[operationResponse.Key] = new OpenApiResponse
            {
                Description = description,
                Content =
                {
                    [MediaTypeNames.Application.ProblemJson] = new OpenApiMediaType
                    {
                        Schema = context.SchemaGenerator.GenerateSchema(typeof(ProblemDetails), context.SchemaRepository)
                    }
                }
            };
        }
    }
}
