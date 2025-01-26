using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using PersonalFinanceApp.Application;
using PersonalFinanceApp.Identity;
using PersonalFinanceApp.Shared.Hosting;
using PersonalFinanceApp.Shared.Hosting.Logging;
using PersonalFinanceApp.Shared.Hosting.Middleware;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();
    Logging.Setup(builder.Environment, builder.Configuration);

    Log.Information("Starting Personal Finance App Identity Service");

    var databaseConnectionString = builder.Configuration
        .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Database Connection String is not configured");
    var dataProtectionThumbprint =
        builder.Configuration["Thumbprint"] ?? throw new InvalidOperationException("Thumbprint is not configured");

    builder.Services.AddDataProtection()
        .SetApplicationName("PersonalFinanceAppIdentityService")
        .PersistKeysToFileSystem(new DirectoryInfo(@"C:\keys\dpKeys"))
        .ProtectKeysWithCertificate(dataProtectionThumbprint);

    builder.Services
        .ConfigureControllers()
        .ConfigureOpenApi(new OpenApiInfo
        {
            Title = "Personal Finance App Identity Service",
            Description = "This document describes the Restful API of the Personal Finance App Identity Service"
        })
        .ConfigureVersioning(defaultApiVersion: new ApiVersion(1, 0))
        .ConfigureApplicationServices()
        .ConfigureIdentity(databaseConnectionString, builder.Configuration);

    var app = builder.Build();

    app.UseSerilogRequestLogging();
    app.UseExceptionHandler();

    if (app.Environment.IsDevelopment())
    {
        app.UseOpenApi(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());
    }

    app.MapControllers();

    app.Run();
}
catch (HostAbortedException) { } // Ignoring - happens when running migrations. Safe to ignore per David Fowler: https://github.com/dotnet/efcore/issues/29809
catch (Exception e)
{
    Log.Fatal(e, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
