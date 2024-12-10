using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PersonalFinanceApp.Shared.Hosting.ExceptionHandlers;
using PersonalFinanceApp.Shared.Hosting.OperationFilters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PersonalFinanceApp.Shared.Hosting;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureOpenApi(this IServiceCollection services, OpenApiInfo apiInfo)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.OperationFilter<ProblemDetailsOperationFilter>();
            options.DescribeAllParametersInCamelCase();

            // Integrate xml comments
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
        });

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>>(sp =>
            new ConfigureSwaggerOptions(apiInfo, sp.GetRequiredService<IApiVersionDescriptionProvider>()));

        return services;
    }

    public static IServiceCollection ConfigureVersioning(this IServiceCollection services, ApiVersion? defaultApiVersion)
    {
        return services
            .AddApiVersioning(options =>
            {
                if (defaultApiVersion is not null)
                {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = defaultApiVersion;
                }

                // Includes headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }
}
