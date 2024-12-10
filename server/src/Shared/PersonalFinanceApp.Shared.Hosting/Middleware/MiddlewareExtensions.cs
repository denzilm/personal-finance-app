using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PersonalFinanceApp.Shared.Hosting.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger(options =>
        {
            options.RouteTemplate = "/swagger/{documentName}/docs/swagger.json";
        });

        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/docs/swagger.json", description.GroupName);
            }

            options.RoutePrefix = "";
            options.DefaultModelExpandDepth(2);
            options.DefaultModelRendering(ModelRendering.Model);
            options.DocExpansion(DocExpansion.None);
        });

        return app;
    }
}
