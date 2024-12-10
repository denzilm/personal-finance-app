using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PersonalFinanceApp.Shared.Hosting;

public sealed class ConfigureSwaggerOptions(OpenApiInfo apiInfo, IApiVersionDescriptionProvider provider)
    : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
        apiInfo.Version = description.ApiVersion.ToString();
        apiInfo.Contact = new OpenApiContact
        {
            Email = "denzilm@example.com",
            Name = "Denzil L. Martin"
        };

        if (description.IsDeprecated)
        {
            apiInfo.Description += "(This API version has been deprecated)";
        }

        return apiInfo;
    }
}
